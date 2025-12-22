class HospitalBill
{
    public double ConsultationFee { get; set; }
    public double TestCharges { get; set; }
    public double RoomCharges { get; set; }

    public double Total()
    {
        return ConsultationFee + TestCharges + RoomCharges;
    }
}