namespace Computers
{
    /// <summary>
    /// common interface, that is used for IN/OUT operations with the RAM and with the Videocard
    /// </summary>
    public interface IMotherboard
    {
        /// <summary>
        /// Loads an integer value from the memory
        /// </summary>
        /// <returnsInteger value, that is stored in the ram</returns>
        int LoadRamValue(); 

        /// <summary>
        /// Save an integer number to the memory
        /// </summary>
        /// <param name="value">must be an integer number</param>
        void SaveRamValue(int value); 

        /// <summary>
        /// Send a string value to the videocard (print it on the display)
        /// </summary>
        /// <param name="data">String value, that will be send (draw) to the videocard</param>
        void DrawOnVideoCard(string data);
    }
}
