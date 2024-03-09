using System.ComponentModel;

namespace FORCEGET.Domain.Enums;

public enum MovementType
{
    [Description("Door to Door")]
    DoorToDoor = 1,
    [Description("Port to Door")]
    PortToDoor,
    [Description("Door to Port")]
    DoorToPort,
    [Description("Port to Port")]
    PortToPort
}