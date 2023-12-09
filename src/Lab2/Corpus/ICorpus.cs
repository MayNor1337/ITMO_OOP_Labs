using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Corpus;

public interface ICorpus : ICorpusDebuilder, IComponent
{
    double MaxHeightGPU { get; }
    double MaxWidthGPU { get; }
    IEnumerable<MotherboardFormFactor> SupportedFormFactor { get; }
    double CorpusHeight { get; }
    double CorpusWidth { get; }
}