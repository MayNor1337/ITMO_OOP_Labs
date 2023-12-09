using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Corpus;

public class Corpus : ICorpus
{
    internal Corpus(double maxHeightGpu, double maxWidthGpu, MotherboardFormFactor[] supportedFormFactor, double corpusHeight, double corpusWidth)
    {
        MaxHeightGPU = maxHeightGpu;
        MaxWidthGPU = maxWidthGpu;
        SupportedFormFactor = supportedFormFactor;
        CorpusHeight = corpusHeight;
        CorpusWidth = corpusWidth;
    }

    public double MaxHeightGPU { get; }
    public double MaxWidthGPU { get; }
    public IEnumerable<MotherboardFormFactor> SupportedFormFactor { get; }
    public double CorpusHeight { get; }
    public double CorpusWidth { get; }

    public ICorpusBuilder Debuilder()
    {
        return new CorpusBuilder().SetMaxHeightGpu(MaxHeightGPU)
            .SetMaxWidthGPU(MaxWidthGPU)
            .SetSupportedFormFactor(SupportedFormFactor)
            .SetCorpusHeight(CorpusHeight)
            .SetCorpusWidth(CorpusWidth);
    }
}