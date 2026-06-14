using System;
using System.Collections.Generic;

namespace Praktychna9;

// Варіант 2: модуль undo/redo дій над групою через делегати.
public class UndoRedoManager
{
    private readonly Stack<Operation> _undoStack = new();
    private readonly Stack<Operation> _redoStack = new();

    private readonly struct Operation
    {
        public string Description { get; }
        public Action Do { get; }
        public Action Undo { get; }

        public Operation(string description, Action doAction, Action undoAction)
        {
            Description = description;
            Do = doAction;
            Undo = undoAction;
        }
    }

    public void Execute(string description, Action doAction, Action undoAction)
    {
        doAction();
        _undoStack.Push(new Operation(description, doAction, undoAction));
        _redoStack.Clear();
    }

    public bool Undo()
    {
        if (_undoStack.Count == 0) return false;
        var op = _undoStack.Pop();
        op.Undo();
        _redoStack.Push(op);
        return true;
    }

    public bool Redo()
    {
        if (_redoStack.Count == 0) return false;
        var op = _redoStack.Pop();
        op.Do();
        _undoStack.Push(op);
        return true;
    }

    public string? LastDescription => _undoStack.Count > 0 ? _undoStack.Peek().Description : null;
    public int UndoCount => _undoStack.Count;
    public int RedoCount => _redoStack.Count;
}
