﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerilogSinksKafkaTest.cs" company="Wes Day">
//   Copyright (c) 2016 Wes Day
//   
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   
//          http://www.apache.org/licenses/LICENSE-2.0
//   
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// <summary>
//   Defines the SerilogSinksKafkaTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Serilog.Sinks.Kafka.Test
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Serilog;

    [TestClass]
    public class SerilogSinksKafkaTest
    {
        [TestMethod]
        [TestCategory("Integration")]
        public void KafkaConnectionTest()
        {
            const string KafkaLoggingTopic = "test";

            var kafkaEndpoints = new[]
            {
                new Uri("http://vcld16rdcsldb06:9092"),
                new Uri("http://vcld16rdcsldb07:9092"),
                new Uri("http://vcld16rdcsldb08:9092")
            };

            var log = new LoggerConfiguration()
                .Enrich.WithMachineName()
                .Enrich.WithProcessId()
                .Enrich.WithThreadId()
                .Enrich.WithEnvironmentUserName()
                .WriteTo.Kafka(KafkaLoggingTopic, kafkaEndpoints)
                .CreateLogger();

            log.Information("This is a test {message}", DateTime.Now.Ticks);
            Assert.AreEqual(true, true);
        }
    }
}
