extends Control

func _ready():
	connect("gui_input", on_gui_input)
func on_gui_input(event):
	if event is InputEventMouseButton && event.pressed && event.button_index == MouseButton.MOUSE_BUTTON_LEFT:
		%User.CaptureMouse()
