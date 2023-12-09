using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Corpus;

public class CorpusBuilder : ICorpusBuilder
{
    private double? _maxHeightGPU;
    private double? _maxWidthGPU;
    private MotherboardFormFactor[]? _supportedFormFactor;
    private double? _corpusHeight;
    private double? _corpusWidth;

    public ICorpusBuilder SetMaxHeightGpu(double maxHeightGPU)
    {
        _maxHeightGPU = maxHeightGPU;
        return this;
    }

    public ICorpusBuilder SetMaxWidthGPU(double maxWidthGPU)
    {
        _maxWidthGPU = maxWidthGPU;
        return this;
    }

    public ICorpusBuilder SetSupportedFormFactor(IEnumerable<MotherboardFormFactor> supportedFormFactor)
    {
        _supportedFormFactor = supportedFormFactor.ToArray();
        return this;
    }

    public ICorpusBuilder SetCorpusHeight(double corpusHeight)
    {
        _corpusHeight = corpusHeight;
        return this;
    }

    public ICorpusBuilder SetCorpusWidth(double corpusWidth)
    {
        _corpusWidth = corpusWidth;
        return this;
    }

    public ICorpus Build()
    {
        return new Corpus(
            _maxHeightGPU ?? throw new ArgumentNullException(nameof(_maxHeightGPU)),
            _maxWidthGPU ?? throw new ArgumentNullException(nameof(_maxWidthGPU)),
            _supportedFormFactor ?? throw new ArgumentNullException(nameof(_supportedFormFactor)),
            _corpusHeight ?? throw new ArgumentNullException(nameof(_corpusHeight)),
            _corpusWidth ?? throw new ArgumentNullException(nameof(_corpusWidth)));
    }
}