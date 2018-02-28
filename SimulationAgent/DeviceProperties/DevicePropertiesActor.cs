﻿// Copyright (c) Microsoft. All rights reserved.

using System;
using Microsoft.Azure.IoTSolutions.DeviceSimulation.Services;
using Microsoft.Azure.IoTSolutions.DeviceSimulation.Services.Concurrency;
using Microsoft.Azure.IoTSolutions.DeviceSimulation.Services.Diagnostics;
using Microsoft.Azure.IoTSolutions.DeviceSimulation.Services.Models;
using Microsoft.Azure.IoTSolutions.DeviceSimulation.SimulationAgent.DeviceConnection;
using Microsoft.Azure.IoTSolutions.DeviceSimulation.SimulationAgent.DeviceState;

namespace Microsoft.Azure.IoTSolutions.DeviceSimulation.SimulationAgent.DeviceProperties
{
    public interface IDevicePropertiesActor
    {
        IInternalDeviceState DeviceState { get; }
        IDeviceClient Client { get; }

        void Setup(
            string deviceId,
            IDeviceStateActor deviceStateActor,
            IDeviceConnectionActor deviceConnectionActor);

        string Run();
        void HandleEvent(DevicePropertiesActor.ActorEvents e);
        void Stop();
    }

    public class DevicePropertiesActor : IDevicePropertiesActor
    {
        private enum ActorStatus
        {
            None,
            ReadyToStart,
            WaitingForUpdate,
            ReadyToUpdate,
            Updating,
            Stopped
        }

        public enum ActorEvents
        {
            Started,
            PropertiesUpdateFailed,
            PropertiesUpdated,
        }

        private readonly ILogger log;
        private readonly IActorsLogger actorLogger;
        private readonly IRateLimiting rateLimiting;
        private readonly IDevicePropertiesLogic updatePropertiesLogic;

        private ActorStatus status;
        private string deviceId;
        private long whenToRun;

        /// <summary>
        /// Reference to the actor managing the device state, used
        /// to retrieve the state and prepare the telemetry messages
        /// </summary>
        private IDeviceStateActor deviceStateActor;

        /// <summary>
        /// Reference to the actor managing the device connection
        /// </summary>
        private IDeviceConnectionActor deviceConnectionActor;

        /// <summary>
        /// State maintained by the state actor
        /// </summary>
        public IInternalDeviceState DeviceState => this.deviceStateActor.DeviceState;

        /// <summary>
        /// Azure IoT Hub client
        /// </summary>
        public IDeviceClient Client => this.deviceConnectionActor.Client;

        /// <summary>
        /// Azure IoT Hub Device instance
        /// </summary>
        public Device Device => this.deviceConnectionActor.Device;

        public DevicePropertiesActor(
            ILogger logger,
            IActorsLogger actorLogger,
            IRateLimiting rateLimiting,
            UpdateReportedProperties updatePropertiesLogic)
        {
            this.log = logger;
            this.actorLogger = actorLogger;
            this.rateLimiting = rateLimiting;
            this.updatePropertiesLogic = updatePropertiesLogic;

            this.status = ActorStatus.None;
            this.deviceId = null;
            this.deviceStateActor = null;
        }

        public void Setup(
            string deviceId,
            IDeviceStateActor deviceStateActor,
            IDeviceConnectionActor deviceConnectionActor)
        {
            // TODO see https://github.com/Azure/device-simulation-dotnet/tree/send-twin-updates
            // for future PR
        }

        public void HandleEvent(DevicePropertiesActor.ActorEvents e)
        {
            // TODO see https://github.com/Azure/device-simulation-dotnet/tree/send-twin-updates
            // for future PR
        }

        public string Run()
        {
            // TODO see https://github.com/Azure/device-simulation-dotnet/tree/send-twin-updates
            // for future PR
            return null;
        }

        public void Stop()
        {
            // TODO see https://github.com/Azure/device-simulation-dotnet/tree/send-twin-updates
            // for future PR
        }

        private void ScheduleTwinUpdate()
        {
            // TODO see https://github.com/Azure/device-simulation-dotnet/tree/send-twin-updates
            // for future PR
        }

        private void ScheduleTwinUpdateRetry()
        {
            // TODO see https://github.com/Azure/device-simulation-dotnet/tree/send-twin-updates
            // for future PR
        }

    }
}