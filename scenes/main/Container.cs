using Godot;
using System.Collections.Generic;
using Orryx.Exporter;

public partial class Container : Node3D
{
    private List<MutableMesh> _meshes = new();
    private MutableMesh _tempMesh = null;
    public void AddCube()
    {
        var meshNode = new MeshInstance3D();
        var mesh = new MutableMesh(meshNode);
        _meshes.Add(mesh);
        AddChild(meshNode);
        mesh.AddCube();
    }
}
