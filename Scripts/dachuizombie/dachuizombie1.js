#pragma strict

var speed = 4.5;	//速度
var rotationSpeed = 5.0;	//角速度
var shootRange = 12.0;		//攻击距离
var attackRange = 25.0;		//仇恨范围
var shootAngle = 4.0;		//攻击角度
var dontComeCloserRange = 10.0;		//敌人最短距离
var delayShootTime = 0.35;			//射击时间
var pickNextWaypointDistance = 12.0;	//寻路
var target : Transform;		//仇恨目标
var ishit = 0;
var die = 0;
var havedie = 0;
var hitleng = 0;
var waittime = 1.5;


var behit : AudioClip;

var bedie : AudioClip;
private var lastShot = -10.0;

// Make sure there is always a character controller
@script RequireComponent (CharacterController)

function Start () {
	// Auto setup player as target through tags
	if (target == null && GameObject.FindWithTag("Player"))
		target = GameObject.FindWithTag("Player").transform;

	Patrol();
}

function Patrol () {
	var curWayPoint = AutoWayPoint.FindClosest(transform.position);
	while (true && die == 0) {
		var waypointPosition = curWayPoint.transform.position;
		// Are we close to a waypoint? -> pick the next one!
		if (Vector3.Distance(waypointPosition, transform.position) < pickNextWaypointDistance)
			curWayPoint = PickNextWaypoint (curWayPoint);
		if (ishit ==1){
				yield StartCoroutine("hit");
			}
		// Attack the player and wait until
		// - player is killed
		// - player is out of sight		
		if (CanSeeTarget ())
			yield StartCoroutine("AttackPlayer");
		
		// Move towards our target
		MoveTowards(waypointPosition);
		
		yield;
	}
}


function CanSeeTarget () : boolean {
	if (Vector3.Distance(transform.position, target.position) > attackRange)
		return false;
		
	var hit : RaycastHit;
	if (Physics.Linecast (transform.position, target.position, hit))
		return hit.transform == target;

	return false;
}

function Shoot () {
	// Start shoot animation
	animation.CrossFade("Attack01", 0.3);
	SendMessage("beingattack");
	// Wait until half the animation has played
	yield WaitForSeconds(delayShootTime);
	
	// Fire gun
	//BroadcastMessage("Fire");
	
	// Wait for the rest of the animation to finish
	yield WaitForSeconds(animation["Attack01"].length - delayShootTime);
}

function isdie(){
	die = 1;
	if(havedie == 0){
	yield StartCoroutine("beingdie");
	havedie = 1;
	}
}

function beingdie(){

	 audio.PlayOneShot(bedie, 0.4/ audio.volume);
	animation.CrossFade("Die", 0.3);
	//animation.CrossFade("Die",1);
	//animation.Play("Die");
	yield WaitForSeconds(delayShootTime);
	yield WaitForSeconds(5);
	Destroy(this.gameObject);
}

function beinghit(){
	ishit = 1;
}

function hit(){
	ishit = 0;
	if(hitleng == 0){
	audio.PlayOneShot(behit);
	animation.CrossFade("Hit01",0.2);
	hitleng = 1;
	hitchong();
	//animation.Play("Die",PlayMode.StopAll);
	yield WaitForSeconds(delayShootTime);
	}
}

function hitchong(){
	yield WaitForSeconds(waittime);
	hitleng = 0;
}

function AttackPlayer () {
	var lastVisiblePlayerPosition = target.position;
	while (true && die == 0) {
		if (CanSeeTarget ()) {
			// Target is dead - stop hunting
			if (target == null)
				return;
			if (ishit ==1){
				yield StartCoroutine("hit");
			}
			// Target is too far away - give up	
			var distance = Vector3.Distance(transform.position, target.position);
			if (distance > shootRange * 3)
				return;
			
			lastVisiblePlayerPosition = target.position;
			if (distance > dontComeCloserRange)
				MoveTowards (lastVisiblePlayerPosition);
			else
				RotateTowards(lastVisiblePlayerPosition);

			var forward = transform.TransformDirection(Vector3.forward);
			var targetDirection = lastVisiblePlayerPosition - transform.position;
			targetDirection.y = 0;

			var angle = Vector3.Angle(targetDirection, forward);

			// Start shooting if close and play is in sight
			if (distance < shootRange && angle < shootAngle && ishit == 0)
				yield StartCoroutine("Shoot");
			//else
				//yield StartCoroutine("hit");
		} else {
			yield StartCoroutine("SearchPlayer", lastVisiblePlayerPosition);
			// Player not visible anymore - stop attacking
			if (!CanSeeTarget ())
				return;
		}

		yield;
	}
}

function SearchPlayer (position : Vector3) {
	// Run towards the player but after 3 seconds timeout and go back to Patroling
	var timeout = 3.0;
	while (timeout > 0.0) {
		MoveTowards(position);

		// We found the player
		if (CanSeeTarget ())
			return;
		if (ishit ==1){
				yield StartCoroutine("hit");
			}
		timeout -= Time.deltaTime;
		yield;
	}
}

function RotateTowards (position : Vector3) {
	SendMessage("SetSpeed", 0.0);
	
	var direction = position - transform.position;
	direction.y = 0;
	if (direction.magnitude < 0.1)
		return;
	
	// Rotate towards the target
	transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
	transform.eulerAngles = Vector3(0, transform.eulerAngles.y, 0);
}

function MoveTowards (position : Vector3) {
	var direction = position - transform.position;
	direction.y = 0;
	if (direction.magnitude < 0.5) {
		SendMessage("SetSpeed", 0.0);
		return;
	}
	
	// Rotate towards the target
	transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
	transform.eulerAngles = Vector3(0, transform.eulerAngles.y, 0);

	// Modify speed so we slow down when we are not facing the target
	var forward = transform.TransformDirection(Vector3.forward);
	var speedModifier = Vector3.Dot(forward, direction.normalized);
	speedModifier = Mathf.Clamp01(speedModifier);

	// Move the character
	direction = forward * speed * speedModifier;
	GetComponent (CharacterController).SimpleMove(direction);
	
	SendMessage("SetSpeed", speed * speedModifier, SendMessageOptions.DontRequireReceiver);
}

function PickNextWaypoint (currentWaypoint : AutoWayPoint) {
	// We want to find the waypoint where the character has to turn the least

	// The direction in which we are walking
	var forward = transform.TransformDirection(Vector3.forward);

	// The closer two vectors, the larger the dot product will be.
	var best = currentWaypoint;
	var bestDot = -10.0;
	for (var cur : AutoWayPoint in currentWaypoint.connected) {
		var direction = Vector3.Normalize(cur.transform.position - transform.position);
		var dot = Vector3.Dot(direction, forward);
		if (dot > bestDot && cur != currentWaypoint) {
			bestDot = dot;
			best = cur;
		}
	}
	
	return best;
}