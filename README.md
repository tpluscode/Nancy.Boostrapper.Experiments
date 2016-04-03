# Nancy.Boostrapper.Experiments
Testing the behaviour of various Nancy bootstrappers

## Why?

I had some issues with Nancy bootstrappers, the `Registrations` class and how various DI containers conusme these registrations.

In this repository I'm comparing the available bootstrappers to see how the operate in different circumstances.

In my opinion the `Registrations` class should help unify the basic container API so that publishers of libraries extending Nancy
can be sure that the behaviour will be the same regardless of the bootstrapper chosen by the consumer.

## The tests

1. `RegisterAll<T>(Lifetime.PerRequest)` - injected as `IEnumerable<T>`
2. Mutiple calls to `Register<T>(Lifetime.PerRequest)` - injected as `IEnumerable<T>`
3. `RegisterAll<T>(Lifetime.Singleton)` - injected as `IEnumerable<T>`
4. Mutiple calls to `Register<T>(Lifetime.Singleton)` - injected as `IEnumerable<T>`
5. `Register<T>(Lifetime.PerRequest)`, where `T` has dependency registered inside bootstrapper

## Test Results

|   | Default | Default (no auto reg) | [Autofac][Autofac] | [DryIoc][DryIoc] | [Grace][Grace] | [MEF][MEF] | [MEF2][MEF2] | [Ninject][Ninject] | [StructureMap][StructureMap] | [Unity][Unity] | [Windsor][Windsor] |
|---| 

## Notes

### MEF

MEF doesn't work at all

### Windsor

Windsor doesn't create a child container but uses a per-request scope. This is a problem for tests and transient registration was
used instead

### LightInject 

LightInject doesn't create a child container. Instead `PerScopeLifetime` must be used

[Autofac]: https://github.com/NancyFx/Nancy.Bootstrappers.Autofac
[DryIoc]: https://github.com/lcssk8board/Nancy.Bootstrappers.DryIoc
[Grace]: https://github.com/ipjohnson/Nancy.Bootstrappers.Grace
[MEF]: https://github.com/wasabii/Nancy.Bootstrappers.Mef
[MEF2]: https://github.com/AaronShiels/Nancy.Bootstrappers.Mef2
[Ninject]: https://github.com/NancyFx/Nancy.Bootstrappers.Ninject
[StructureMap]: https://github.com/NancyFx/Nancy.Bootstrappers.StructureMap
[Unity]: https://github.com/NancyFx/Nancy.Bootstrappers.Unity
[Windsor]: https://github.com/NancyFx/Nancy.Bootstrappers.Windsor
