namespace HotelSystem
{
    interface ISaving
    {
        void WriteBIN(string nazwa);
        object ReadBIN(string nazwa);
    }
}
