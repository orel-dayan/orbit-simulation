using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewtonianOrbit : MonoBehaviour
{
    /// The gravitational constant used in the simulation. Determines the strength of the gravitational attraction.
    public const float GravitationalConstant = 0.0001f;
    // The time step used in the simulation. Determines the speed of the simulation.
    public const float TimeStep = 0.1f;

    [SerializeField] private float mass;
    [SerializeField] private float radius; 
    [SerializeField] private Vector3 initialVelocity;
    [SerializeField] private NewtonianOrbit parentBody;

    private Vector3 velocityVector;

    public float Mass => mass; // The mass of the object
    public Vector3 InitialVelocity => initialVelocity; // The initial velocity of the object
    public NewtonianOrbit ParentBody => parentBody; // The parent body of the object

    private void Awake()
    {
        velocityVector = initialVelocity;
    }
 
    /// OnValidate is called when the script is loaded or a value is changed in the inspector. Handles the scaling of the object based on the radius.
    private void OnValidate()
    {
        transform.localScale = Vector3.one * radius * 2f; // Set the scale of the object based on the radius
      
    }
     /// Update is called every frame. Handles the calculation of gravitational forces and updates the position of the object.

    private void Update()
    {
        if (parentBody == null)
        {
            return;
        }

        Vector3 difference = parentBody.transform.position - transform.position;
        float distanceSquared = difference.sqrMagnitude;
    
        Vector3 acceleration = difference.normalized* GravitationalConstant * (mass * parentBody.Mass) / distanceSquared; // Appliction of Newton's law of universal gravitation, F = G ((m1*m2) / r^2)
        velocityVector += acceleration * TimeStep; // Update the velocity vector
        transform.position += velocityVector; // Update the position of the object

    }
}