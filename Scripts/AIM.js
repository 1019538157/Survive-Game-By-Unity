#pragma strict


function Start () {
	// Set all animations to loop
	animation.wrapMode = WrapMode.Loop;

	// Except our action animations, Dont loop those
	animation["Attack01"].wrapMode = WrapMode.Once;
	animation["Hit01"].wrapMode = WrapMode.Once;
	
	// Put idle and run in a lower layer. They will only animate if our action animations are not playing
	animation["Stand"].layer = -1;
	animation["Walk"].layer = -1;
	
	animation.Stop();
}

function SetSpeed (speed : float) {
		animation.CrossFade("Walk");
}