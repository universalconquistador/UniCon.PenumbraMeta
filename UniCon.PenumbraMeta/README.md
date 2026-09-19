# UniCon.PenumbraMeta Project

## Reading Metadata

To read a V3 or V4 mod metadata file use the `PenumbraModMeta.FromStreamAsync` function, making sure to catch any `JsonException`s as appropriate, like so:

```csharp
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
    // (Handle exception here)
}
```

Once you have the mod metadata parsed into a `PenumbraModMeta` you can use its common base class properties, or you can check its type for either `PenumbraModMetaV3` or `PenumbraModMetaV4` and handle it as desired, like so:

```csharp
if (mod is PenumbraModMetaV3 modV3)
{
    // (Work with modV3)
}
else if (mod is PenumbraModMetaV4 modV4)
{
    // (Work with modV4)
}
```

### Reading Conditions, Groups, and Manipulations

`Condition`s, `Group`s, and `Manipulation`s are all abstract base classes with many subclasses, and it can be difficult to work with such hierarchies. In UniCon.PenumbraMeta, each of these types implements the 'Visitor Pattern', which gives you the option of of using the `IConditionVisitor`, `IGroupVisitor`, and `IManipulationVisitor` to work with them in a type-safe, performant way. For an example of how to do this, check out the demo project and its README.

## Writing Metadata

To write a V3 or V4 mod metadata file, create or acquire a `PenumbraModMeta` and use its `SerializeToStreamAsync` method, like so:

```csharp
PenumbraModMeta mod = new PenumbraModMetaV4(...);
using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write))
{
    await mod.SerializeToStreamAsync(stream);
}
```
