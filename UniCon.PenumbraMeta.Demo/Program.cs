using System.Text;
using System.Text.Json;
using UniCon.PenumbraMeta.Conditions;
using UniCon.PenumbraMeta.Groups;
using UniCon.PenumbraMeta.Manipulations;

namespace UniCon.PenumbraMeta.Demo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            PenumbraModMeta? mod = null;
            try
            {
                using (var stream = new FileStream(args[0], FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    mod = await PenumbraModMeta.FromStreamAsync(stream);
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Failed to read metadata. Exception: " + ex.ToString());
            }
            
            if (mod == null)
            {
                Console.WriteLine("Could not deserialize.");
                return;
            }

            Console.WriteLine($"Name: {mod.Name}");
            Console.WriteLine($"Author: {mod.Author ?? "<null>"}");
            Console.WriteLine($"Description: {mod.Description?.Replace("\n", "\n    ") ?? "<null>"}");
            Console.WriteLine($"Image: {mod.Image ?? "<null>"}");
            Console.WriteLine($"Version: {mod.Version ?? "<null>"}");
            Console.WriteLine($"Website: {mod.Website ?? "<null>"}");
            Console.WriteLine($"Mod Tags: [{(mod.ModTags != null ? String.Join(", ", mod.ModTags) : "<null>")}]");
            Console.WriteLine($"Default Preferred Items: [{(mod.DefaultPreferredItems != null ? String.Join(", ", mod.DefaultPreferredItems.Select(itemId => itemId.ToString())) : "<null>")}]");

            if (mod is PenumbraModMetaV3 modV3)
            {
                Console.WriteLine($"V3 Required Features: [{(modV3.RequiredFeatures != null ? String.Join(", ", modV3.RequiredFeatures) : "<null>")}]");
            }
            else if (mod is PenumbraModMetaV4 modV4)
            {
                Console.WriteLine($"V4 Required Features: [{(modV4.RequiredFeatures != null ? String.Join(", ", modV4.RequiredFeatures.Select(feature => feature.ToString())) : "<null>")}]");
                Console.WriteLine($"V4 Identifier: {modV4.Identifier?.ToString() ?? "<null>"}");
                Console.WriteLine($"V4 Last Write: {modV4.LastWrite?.ToString() ?? "<null>"}");
                Console.Write($"V4 Default Data: ");
                if (modV4.DefaultData == null)
                {
                    Console.WriteLine("<null>");
                }
                else
                {
                    Console.WriteLine();
                    PrintContainer(modV4.DefaultData);
                }
                Console.Write("V4 Groups: ");
                if (modV4.Groups == null)
                {
                    Console.WriteLine("<null>");
                }
                else
                {
                    Console.WriteLine();
                    StringBuilder builder = new();
                    foreach (var group in modV4.Groups)
                    {
                        Console.WriteLine($"    Name {group.Name} version {group.Version}, Description: {group.Description?.Replace("\n", "\n    ") ?? "<null>"}, Image: {group.Image ?? "<null>"}, Page {group.Page}, Priority {group.Priority}, Default Settings: {group.DefaultSettings}, Id: {group.Id}, Layout: {(group.Layout != null ? String.Join(", ", group.Layout.Select(layout => layout.ToString())) : "<null>")}");
                        builder.Clear();
                        group.Condition?.Visit<ConditionPrinter, StringBuilder, object?>(ref builder);
                        Console.WriteLine($"    Condition: {(group.Condition != null ? builder.ToString() : "<null>")}");

                        object? param = null;
                        group.Visit<GroupPrinter, object?, object?>(ref param);
                    }
                }
                Console.Write("V4 Page Names: ");
                if (modV4.PageNames == null)
                {
                    Console.WriteLine("<null>");
                }
                else
                {
                    Console.WriteLine();
                    foreach (var pair in modV4.PageNames)
                    {
                        Console.WriteLine($"    {pair.Key} = \"{pair.Value}\"");
                    }
                }
            }
        }

        public static void PrintContainer(IContainer container)
        {
            Console.WriteLine($"        Files[{container.Files?.Count.ToString() ?? "<null>"}]:");
            if (container.Files != null)
            {
                foreach (var file in container.Files)
                {
                    Console.WriteLine($"            {file.Key} => {file.Value}");
                }
            }
            Console.WriteLine($"        File Swaps[{container.FileSwaps?.Count.ToString() ?? "<null>"}]:");
            if (container.FileSwaps != null)
            {
                foreach (var swap in container.FileSwaps)
                {
                    Console.WriteLine($"            {swap.Key} => {swap.Value}");
                }
            }
            Console.WriteLine($"        Manipulations[{container.Manipulations?.Count.ToString() ?? "<null>"}]:");
            if (container.Manipulations != null)
            {
                foreach (var manipulation in container.Manipulations)
                {
                    object? param = null;
                    var manipulationString = manipulation.Visit<ManipulatorPrinter, object?, string>(ref param);
                    Console.WriteLine($"            {manipulationString}");
                }
            }
        }

        public static void PrintOption(IOption option)
        {
            Console.WriteLine($"        Name: {option.Name}, Description: {option.Description ?? "<null>"}, Priority: {option.Priority}, Image: {option.Image ?? "<null>"}, Id: {option.Id}, Layout Options: {(option.Layout != null ? String.Join(", ", option.Layout.Select(layout => layout.ToString())) : "<null>")}, Color: {option.Color}");
            if (option.Condition != null)
            {
                var sb = new StringBuilder();
                option.Condition.Visit<ConditionPrinter, StringBuilder, object?>(ref sb);
                Console.WriteLine($"        Condition: {sb}");
            }
            else
            {
                Console.WriteLine("        Condition: <null>");
            }
        }

        /// <summary>
        /// Returns info about a <see cref="Manipulation"/> as a string.
        /// </summary>
        public class ManipulatorPrinter : IManipulationVisitor<object?, string>
        {
            public static string VisitAtchManipulation(AtchManipulation manipulation, ref object? param) => $"Atch: {manipulation.Manipulation.Gender} {manipulation.Manipulation.Race}, Type {manipulation.Manipulation.Type}, Index {manipulation.Manipulation.Index}: Bone {manipulation.Manipulation.Entry.Bone}, Scale {manipulation.Manipulation.Entry.Scale}, Offset <{manipulation.Manipulation.Entry.OffsetX}, {manipulation.Manipulation.Entry.OffsetY}, {manipulation.Manipulation.Entry.OffsetZ}>, Rotation <{manipulation.Manipulation.Entry.RotationX}, {manipulation.Manipulation.Entry.RotationY}, {manipulation.Manipulation.Entry.RotationZ}>";
            public static string VisitAtrManipulation(AtrManipulation manipulation, ref object? param) => $"Atr: {manipulation.Manipulation.Attribute} on {manipulation.Manipulation.Slot} for body {manipulation.Manipulation.Id}: {(manipulation.Manipulation.Entry ? "Enabled" : "Disabled")}";
            public static string VisitEqdpManipulation(EqdpManipulation manipulation, ref object? param) => $"Eqdp: Model Set {manipulation.Manipulation.SetId} on {manipulation.Manipulation.Slot} for {manipulation.Manipulation.Gender} {manipulation.Manipulation.Race}: {manipulation.Manipulation.Entry}";
            public static string VisitEqpManipulation(EqpManipulation manipulation, ref object? param) => $"Eqp: Model Set {manipulation.Manipulation.SetId} on {manipulation.Manipulation.Slot}: {manipulation.Manipulation.Entry}";
            public static string VisitEstManipulation(EstManipulation manipulation, ref object? param) => $"Est: Model Set {manipulation.Manipulation.SetId} on {manipulation.Manipulation.Slot} for {manipulation.Manipulation.Gender} {manipulation.Manipulation.Race}: {manipulation.Manipulation.Entry}";
            public static string VisitGeqpManipulation(GeqpManipulation manipulation, ref object? param) => $"Geqp: {manipulation.Manipulation.Type} for {manipulation.Manipulation.Condition}";
            public static string VisitGmpManipulation(GmpManipulation manipulation, ref object? param) => $"Gmp: Model Set {manipulation.Manipulation.SetId}, Enabled: {manipulation.Manipulation.Entry.Enabled}, Animated: {manipulation.Manipulation.Entry.Animated}, Rotation: <{manipulation.Manipulation.Entry.RotationA}, {manipulation.Manipulation.Entry.RotationB}, {manipulation.Manipulation.Entry.RotationC}>, Unknown A: {manipulation.Manipulation.Entry.UnknownA}, Unknown B: {manipulation.Manipulation.Entry.UnknownB}";
            public static string VisitImcManipulation(ImcManipulation manipulation, ref object? param) => $"Imc: {manipulation.Manipulation.ObjectType} Model {manipulation.Manipulation.PrimaryId} {manipulation.Manipulation.SecondaryId} {manipulation.Manipulation.Variant} on {manipulation.Manipulation.EquipSlot} {manipulation.Manipulation.BodySlot}: Material {manipulation.Manipulation.Entry.MaterialId}, Decal {manipulation.Manipulation.Entry.DecalId}, VFX {manipulation.Manipulation.Entry.VfxId}, Material Animation {manipulation.Manipulation.Entry.MaterialAnimationId}, Sound {manipulation.Manipulation.Entry.SoundId}, Attribute Mask {manipulation.Manipulation.Entry.AttributeMask}";
            public static string VisitRspManipulation(RspManipulation manipulation, ref object? param) => $"Rsp: {manipulation.Manipulation.SubRace} {manipulation.Manipulation.Attribute}: {manipulation.Manipulation.Entry}";
            public static string VisitShpManipulation(ShpManipulation manipulation, ref object? param) => $"Shp: {manipulation.Manipulation.Slot} for {manipulation.Manipulation.GenderRaceCondition} model {manipulation.Manipulation.Id}: Shape {manipulation.Manipulation.Shape}, Enabled {manipulation.Manipulation.Entry}, Connector Condition {manipulation.Manipulation.ConnectorCondition}";
            public static string VisitUnknownManipulation(UnknownManipulation manipulation, ref object? param) => $"Unknown Meta Manip: {manipulation.Manipulation.GetType().FullName} ({manipulation.Manipulation})";
        }

        /// <summary>
        /// Prints information about a <see cref="Group"/> to standard output.
        /// </summary>
        public class GroupPrinter : IGroupVisitor<object?, object?>
        {
            public static object? VisitCombiningGroup(CombiningGroup combiningGroup, ref object? param)
            {
                Console.WriteLine("    Options: ");
                foreach (var option in combiningGroup.Options)
                {
                    PrintOption(option);
                }
                Console.WriteLine("    Containers: ");
                foreach (var container in combiningGroup.Containers)
                {
                    Console.WriteLine($"        Name: {container.Name ?? "<null>"}");
                    PrintContainer(container);
                }
                return null;
            }

            public static object? VisitImcGroup(ImcGroup imcGroup, ref object? param)
            {
                Console.WriteLine($"    All Variants: {imcGroup.AllVariants}, Only Attributes: {imcGroup.OnlyAttributes}, Identifier: {imcGroup.Identifier.ObjectType} Model {imcGroup.Identifier.PrimaryId} {imcGroup.Identifier.SecondaryId} {imcGroup.Identifier.Variant} on {imcGroup.Identifier.EquipSlot} {imcGroup.Identifier.BodySlot}: Default Material {imcGroup.DefaultEntry.MaterialId}, Default Decal {imcGroup.DefaultEntry.DecalId}, Default VFX {imcGroup.DefaultEntry.VfxId}, Default Material Animation {imcGroup.DefaultEntry.MaterialAnimationId}, Default Sound {imcGroup.DefaultEntry.SoundId}, Default Attribute Mask {imcGroup.DefaultEntry.AttributeMask}");
                Console.WriteLine("    Options: ");
                foreach (var option in imcGroup.Options)
                {
                    PrintOption(option);
                }
                return null;
            }

            public static object? VisitMultiGroup(MultiGroup multiGroup, ref object? param)
            {
                Console.WriteLine("    Options: ");
                foreach (var containerOption in multiGroup.Options)
                {
                    PrintOption(containerOption);
                    PrintContainer(containerOption);
                }
                return null;
            }

            public static object? VisitSingleGroup(SingleGroup singleGroup, ref object? param)
            {
                Console.WriteLine("    Options: ");
                foreach (var containerOption in singleGroup.Options)
                {
                    PrintOption(containerOption);
                    PrintContainer(containerOption);
                }
                return null;
            }
        }

        /// <summary>
        /// Appends a pretty-printed representation of a <see cref="Condition"/> to a <see cref="StringBuilder"/>.
        /// </summary>
        public class ConditionPrinter : IConditionVisitor<StringBuilder, object?>
        {
            public static object? VisitSettingCondition(SettingCondition settingCondition, ref StringBuilder param)
            {
                param.Append($"Setting {settingCondition.Setting}");
                return null;
            }

            public static object? VisitAndCondition(AndCondition andCondition, ref StringBuilder param)
            {
                if (andCondition.Conditions == null || andCondition.Conditions.Count == 0)
                {
                    param.Append("(Empty And)");
                }
                else
                {
                    param.Append('(');
                    for (int i = 0; i < andCondition.Conditions.Count; i++)
                    {
                        andCondition.Conditions[i].Visit<ConditionPrinter, StringBuilder, object?>(ref param);
                        if (i < andCondition.Conditions.Count - 1)
                        {
                            param.Append(" And ");
                        }
                    }
                    param.Append(')');
                }
                return null;
            }

            public static object? VisitFalseCondition(FalseCondition falseCondition, ref StringBuilder param)
            {
                param.Append("False");
                return null;
            }

            public static object? VisitNotCondition(NotCondition notCondition, ref StringBuilder param)
            {
                param.Append("(Not ");
                notCondition.Condition.Visit<ConditionPrinter, StringBuilder, object?>(ref param);
                param.Append(')');
                return null;
            }

            public static object? VisitOrCondition(OrCondition orCondition, ref StringBuilder param)
            {
                if (orCondition.Conditions == null || orCondition.Conditions.Count == 0)
                {
                    param.Append("(Empty Or)");
                }
                else
                {
                    param.Append('(');
                    for (int i = 0; i < orCondition.Conditions.Count; i++)
                    {
                        orCondition.Conditions[i].Visit<ConditionPrinter, StringBuilder, object?>(ref param);
                        if (i < orCondition.Conditions.Count - 1)
                        {
                            param.Append(" Or ");
                        }
                    }
                    param.Append(')');
                }
                return null;
            }

            public static object? VisitTrueCondition(TrueCondition trueCondition, ref StringBuilder param)
            {
                param.Append("True");
                return null;
            }
        }
    }
}
