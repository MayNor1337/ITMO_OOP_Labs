using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

public interface IEngine
{
    bool TryPassTrack(EnvironmentType type, int lengthPath, out Fuel? fuel);
}
