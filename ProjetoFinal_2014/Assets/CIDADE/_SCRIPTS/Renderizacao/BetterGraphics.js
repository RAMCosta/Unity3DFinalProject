#pragma strict

var culRange : int = 100;
 var softCulling : boolean = false;
 
 function OnEnable() {
     for(var toCul : Transform in transform) { //get all objects we want to cul. Place them as childs of the gamobject that's script is attched
         TurnOnOff(toCul, false);
         CheckRange(toCul, 0);
     }
 }
 
 function CheckRange(toCul : Transform, waitFor : int) : IEnumerator {
     yield WaitForSeconds(waitFor);
     var curRange : int = Vector3.Distance(Camera.main.transform.position, toCul.position); //range from the camera to the object
     if (curRange < culRange) { //if in range acivate/make visible
         TurnOnOff(toCul, true);
     } else { //out of range -> deactivate/invisible
         TurnOnOff(toCul, false);
     }
     var checkIn = Mathf.Max(0.5, 5*curRange/culRange); //the next check depends on the range from the camera to the object (for better performance)
     //print("Check for " + toCul.name + " in " + checkIn + " seconds."); //for debug
     CheckRange(toCul, checkIn);
 }
 
 function TurnOnOff(toCul : Transform, state : boolean) {
     if (!softCulling) {
         toCul.gameObject.SetActive(state); //deactivate the object(s)
     } else {
         for (var r : Renderer in toCul.GetComponentsInChildren(Renderer)) {
               r.enabled = state; //make the object(s) invisible
         }
     }
 }
 
 function OnDrawGizmosSelected () { //draw a debug sphere to visualize the culRange, not needed for functionality
     Gizmos.color = Color.yellow;
     for(var toCul : Transform in transform) {
          Gizmos.DrawWireSphere(toCul.position, culRange);
     }
 }