using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class RunAwayAT : ActionTask {

		GameObject tail;

        public BBParameter<UnityEngine.Vector3> localTarget;

        int destination;

        public NavMeshAgent nmAgent;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            tail = GameObject.FindGameObjectWithTag("Tail");
            nmAgent = agent.GetComponent<NavMeshAgent>();
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

            destination = Random.Range(1, 8);

			nmAgent.speed = 7;


            localTarget.value = GameObject.FindGameObjectWithTag(destination.ToString()).transform.position;
			
            tail.transform.eulerAngles = new Vector3(0, 0, 80);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {

			nmAgent.speed = 3.5f;

            tail.transform.eulerAngles = Vector3.zero;
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}