using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class DefendAT : ActionTask {

        public BBParameter<UnityEngine.Vector3> localTarget;

        GameObject player;

        public Material lizard;

        public Material angry;

        public NavMeshAgent nmAgent;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            player = GameObject.FindGameObjectWithTag("Player");
            nmAgent = agent.GetComponent<NavMeshAgent>();
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

            foreach (Renderer lizardPiece in agent.transform.GetComponentsInChildren<Renderer>())
            {
                lizardPiece.material = angry;
            }

            localTarget.value = GameObject.FindGameObjectWithTag("NestNode").transform.position;

            nmAgent.speed = 7;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
			if (Vector3.Distance(localTarget.value, player.transform.position) >= 5)
            {
                EndAction();
            }

		}

		//Called when the task is disabled.
		protected override void OnStop() {

            nmAgent.speed = 3.5f;

            foreach (Renderer lizardPiece in agent.transform.GetComponentsInChildren<Renderer>())
            {
                lizardPiece.material = lizard;
            }
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}