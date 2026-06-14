namespace Praktychna8;

public interface IResizable
{
    void Resize(double factor);
}

public interface IDrawable
{
    void Draw();
}

public interface IPrintable
{
    string GetPrintInfo();
}
