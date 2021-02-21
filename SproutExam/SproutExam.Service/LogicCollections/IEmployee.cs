namespace SproutExam.Service.LogicCollections
{
    public interface IEmployee
    {
        /// <summary>
        /// Computes the specified input to be compute.
        /// </summary>
        /// <param name="inputToBeCompute">Regular Employee: Absences in days. Contractual Employee: Number of work days</param>
        /// <returns></returns>
        double Compute(double inputToBeCompute);
    }
}
