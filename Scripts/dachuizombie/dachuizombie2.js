#pragma strict

function Start () {
	// Set all animations to loop
	animation.wrapMode = WrapMode.Loop;

	// Except our action animations, Dont loop those
	animation["Attack01"].wrapMode = WrapMode.Once;
	animation["Hit01"].wrapMode = WrapMode.Once;
	animation["Die"].wrapMode = WrapMode.ClampForever;
	//animation["Die"].wrapMode = WrapMode.Loop;
	
	// Put idle and run in a lower layer. They will only animate if our action animations are not playing
	animation["Hit01"].layer =2;
	animation["Die"].layer =3;
	animation["Attack01"].layer =1;
	animation["Stand"].layer = -1;
	animation["Walk"].layer = -1;
	
	animation.Stop();
}

function SetSpeed (speed : float) {
	if (speed > 0)
		animation.CrossFade("Walk");
	else
		animation.CrossFade("Stand");
		;
}