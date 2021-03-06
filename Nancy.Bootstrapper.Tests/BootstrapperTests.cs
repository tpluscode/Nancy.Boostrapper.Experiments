﻿using Nancy.Bootstrapper.Tests.Bootstrappers;
using Nancy.Testing;
using Xunit;

namespace Nancy.Bootstrapper.Tests
{
    public abstract class BootstrapperTests<TBs> where TBs : INancyBootstrapper, new()
    {
        [Fact]
        public void Test5_TypeRegisteredPerRequestAsCollection_Should_BeInjectedAsCollection()
        {
            // given
            var browser = new Browser(new TBs());

            // when
            var response = browser.Get("per-request/multiple");

            // then
            Assert.Equal("2", response.Body.AsString());
        }

        [Fact]
        public void Test4_TypeRegisteredPerRequestAsIndividuals_Should_BeInjectedAsCollection()
        {
            // given
            var browser = new Browser(new TBs());

            // when
            var response = browser.Get("per-request/individuals");

            // then
            Assert.Equal("4", response.Body.AsString());
        }

        [Fact]
        public void Test2_TypeRegisteredAsSingletonsAsIndividuals_Should_BeInjectedAsCollection()
        {
            // given
            var browser = new Browser(new TBs());

            // when
            var response = browser.Get("singletons/individuals");

            // then
            Assert.Equal("4", response.Body.AsString());
        }

        [Fact]
        public void Test3_TypeRegisteredAsSingletonsAsMultiple_Should_BeInjectedAsCollection()
        {
            // given
            var browser = new Browser(new TBs());

            // when
            var response = browser.Get("singletons/multiple");

            // then
            Assert.Equal("2", response.Body.AsString());
        }

        [Fact]
        public void Test1_TypeRegisteredAsPerRequest_Should_BeInjectedWithDependencyRegistereInBootstrapper()
        {
            // given
            var browser = new Browser(new TBs());

            // when
            var response = browser.Get("mixed/per-request/depends-on/container-registered");

            // then
            Assert.Equal("I'm ok", response.Body.AsString());
        }

        [Fact]
        public void Test6_InjectingPerRequestComponentIntoRequestStartup()
        {
            // given
            var browser = new Browser(new TBs());

            // when
            var response = browser.Get("startup/value");

            // then
            Assert.Equal("hello request startup", response.Body.AsString());
        }
    }

    public class WindsorBootsrapperTests : BootstrapperTests<WindsorBootstrapper>
    {
    }

    public class AutofacBootstrapperTests : BootstrapperTests<AutofacBootstrapper>
    {
    }

    public class DefaultBootstrapperNoAutoregistrationTests : BootstrapperTests<DefaultBootstrapperNoAutoregistration>
    {
    }

    public class DefaultNancyBootstrapperTests : BootstrapperTests<DefaultNancyBootstrapper>
    {
    }

    public class DryIocBootstrapperTests : BootstrapperTests<DryIocBootstrapper>
    {
    }

    public class GraceBootsrapperTests : BootstrapperTests<GraceBootstrapper>
    {
    }

    public class NinjectBootsrapperTests : BootstrapperTests<NinjectBootstrapper>
    {
    }

    public class StructureMapBootsrapperTests : BootstrapperTests<StructureMapBootstrapper>
    {
    }

    public class UnityBootsrapperTests : BootstrapperTests<UnityBootstrapper>
    {
    }

    public class Mef2BootsrapperTests : BootstrapperTests<Mef2Bootstrapper>
    {
    }

    //public class MefBootsrapperTests : BootstrapperTests<MefBootstrapper>
    //{
    //}

    public class LightInjectBootsrapperTests : BootstrapperTests<LightInjectBootstrapper>
    {
    }
}
