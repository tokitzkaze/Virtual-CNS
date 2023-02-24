using UdonSharp;
using UnityEngine;

namespace VirtualFlightDataBus
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class CourseIndicator : AbstractFlightDataBusClient
    {
        public int id = 1;
        public Vector3 axis = Vector3.back;
        private FlightDataFloatValueId courseId;

        protected override void OnStart()
        {
            courseId = FlightDataUtilities.OffsetValueId(FlightDataFloatValueId.Nav1Course, id - 1);
            _Subscribe(courseId);
        }

        public override void _OnFloatValueChanged()
        {
            transform.localRotation = Quaternion.AngleAxis(_Read(courseId), axis);
        }
    }
}