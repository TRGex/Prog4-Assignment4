using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class WanderAT : ActionTask {

        GameObject neck;

        public BBParameter<UnityEngine.Vector3> localTarget;

		int destination;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            neck = GameObject.FindGameObjectWithTag("Neck");
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			destination = Random.Range(1, 8);


            localTarget.value = GameObject.FindGameObjectWithTag(destination.ToString()).transform.position;

            neck.transform.eulerAngles = new Vector3(0, 0, -35);


            EndAction();
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}