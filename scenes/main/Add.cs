using Godot;

public partial class Add : Button
{
    private Tree _tree;
    private Container _container;
    public override void _Ready()
    {
        _tree = GetNode<Tree>("%Tree");
        _container = GetNode<Container>("%Container");
    }
    public override void _Pressed()
    {
        var item = _tree.CreateItem(_tree.GetSelected());
        // TODO
    }
}
