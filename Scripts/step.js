﻿#pragma strict

var walkSounds : AudioClip[];
var audioStepLength = 0.3;

function Start () {
    PlayStepSounds();
}
function Awake () {
	
    PlayStepSounds();
}

function Update () {

}

function PlayStepSounds () {
    var controller : CharacterController = GetComponent(CharacterController);

    while (true) {
        if (controller.isGrounded && controller.velocity.magnitude > 0.3) {
            audio.clip = walkSounds[Random.Range(0, walkSounds.length)];
            audio.Play();
            //yield;
            yield WaitForSeconds(audioStepLength);
        } else {
            yield;
        }
    }
}
