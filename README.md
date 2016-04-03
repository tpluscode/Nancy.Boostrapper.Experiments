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

| Test ------------------>     | 1  | 2  | 3  | 4  | 5  |
| ---------------------------- |----|----|----|----|----| 
| Default                      |:+1:|:+1:|:+1:|:+1:|:x: |
| Default (no auto reg)        |:+1:|:x: |:+1:|:x: |:+1:|
| [Autofac][Autofac]           |:+1:|:+1:|:+1:|:+1:|:+1:|
| [DryIoc][DryIoc]             |:+1:|:+1:|:+1:|:+1:|:+1:|
| [Grace][Grace]               |:x: |:x: |:x: |:x: |:x: |
| [LightInject][LightInject]   |:+1:|:x: |:+1:|:x: |:+1:|
| [MEF][MEF]                   |:x: |:x: |:x: |:x: |:x: |
| [MEF2][MEF2]                 |:+1:|:+1:|:x: |:+1:|:x: |
| [Ninject][Ninject]           |:+1:|:+1:|:+1:|:+1:|:+1:|
| [StructureMap][StructureMap] |:+1:|:+1:|:+1:|:+1:|:+1:|
| [Unity][Unity]               |:+1:|:x: |:+1:|:x: |:+1:|
| [Windsor][Windsor]           |:+1:|:+1:|:+1:|:+1:|:+1:|

## General notes

### Grace

Grace has an outdated Nancy dependency and doesn't work with latest version.

### MEF

MEF doesn't work at all and even adding a reference breaks entire solution.

### Windsor

Windsor doesn't create a child container but uses a per-request scope. This is a problem for tests and transient registration was
used instead

### LightInject 

LightInject doesn't create a child container. Instead `PerScopeLifetime` must be used. 

LightInject requires .NET 4.5.1

### Unity

Unity bootstrapper has a dependency on Unity >= 2.1.505 and works fine with version 3.5, but breaks with 4.0.

[Autofac]: https://github.com/NancyFx/Nancy.Bootstrappers.Autofac
[DryIoc]: https://github.com/lcssk8board/Nancy.Bootstrappers.DryIoc
[Grace]: https://github.com/ipjohnson/Nancy.Bootstrappers.Grace
[MEF]: https://github.com/wasabii/Nancy.Bootstrappers.Mef
[MEF2]: https://github.com/AaronShiels/Nancy.Bootstrappers.Mef2
[Ninject]: https://github.com/NancyFx/Nancy.Bootstrappers.Ninject
[StructureMap]: https://github.com/NancyFx/Nancy.Bootstrappers.StructureMap
[Unity]: https://github.com/NancyFx/Nancy.Bootstrappers.Unity
[Windsor]: https://github.com/NancyFx/Nancy.Bootstrappers.Windsor
[LightInject]: http://seesharper.github.io/LightInject/#nancy
