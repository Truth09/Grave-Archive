using UnityEngine;
using System.Collections.Generic;

public class NodeData
{
    public int id;
    public NodeType type;
    public int layer;
    public List<NodeData> connections = new List<NodeData>();
}


public enum NodeType
{
    Battle,
    CardGift,
    CardTrade,
    CardDelete
}
