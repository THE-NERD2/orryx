extends Tree

var prevSelected: TreeItem = null

func _ready():
	# Create root node
	var root = create_item()
	root.set_text(0, "root")
	# Connect signal to tree item selected
	item_selected.connect(_on_tree_item_selected)
func _on_tree_item_selected():
	if prevSelected != null:
		prevSelected.set_editable(0, false)
	prevSelected = get_selected()
	await get_tree().create_timer(0.1).timeout
	prevSelected.set_editable(0, true)
