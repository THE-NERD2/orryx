using System.Collections.Generic;
using Godot;

namespace Orryx.Exporter.Mesh;

public class MutableMesh
{
    public MeshInstance3D Node;
    public List<MeshDataTool> Surfaces = new();
    public MutableMesh(MeshInstance3D node)
    {
        Node = node;
    }
    public void AddCube()
    {
        var newMesh = new ArrayMesh();
        newMesh.AddSurfaceFromArrays(Godot.Mesh.PrimitiveType.Triangles, new BoxMesh().GetMeshArrays());
        var data = new MeshDataTool();
        data.CreateFromSurface(newMesh, 0);
        Surfaces.Add(data);
        UpdateNode();
    }
    public void UpdateNode()
    {
        var mesh = new ArrayMesh();
        foreach(var surface in Surfaces)
        {
            surface.CommitToSurface(mesh);
        }
        Node.Mesh = mesh;
    }
}