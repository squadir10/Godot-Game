using Godot;
using System;

public partial class Pink_Man : CharacterBody2D
{
	public const float Speed = 400.0f;
	public const float JumpVelocity = -600.0f;
	private AnimatedSprite2D Sprite2D;

	public override void _Ready()
    {
        Sprite2D = GetNode<AnimatedSprite2D>("Sprite2D");
		GD.Print(Sprite2D);
    }


	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	

    
    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;

		

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		// Only change the velocity and flip the sprite if there is input.
		if (Input.IsActionPressed("ui_right")){
			velocity.X = Speed;
			Sprite2D.FlipH = false; //face right
		}
		else if (Input.IsActionPressed ("ui_left"))
		{
			velocity.X = -Speed;
			Sprite2D.FlipH = true; //Face left
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();

		
		
	}
}
