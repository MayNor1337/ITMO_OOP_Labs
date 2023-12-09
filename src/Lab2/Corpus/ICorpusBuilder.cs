using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Corpus;

public interface ICorpusBuilder
{
    ICorpusBuilder SetMaxHeightGpu(double maxHeightGPU);

    ICorpusBuilder SetMaxWidthGPU(double maxWidthGPU);

    ICorpusBuilder SetSupportedFormFactor(IEnumerable<MotherboardFormFactor> supportedFormFactor);

    ICorpusBuilder SetCorpusHeight(double corpusHeight);

    ICorpusBuilder SetCorpusWidth(double corpusWidth);

    ICorpus Build();
}