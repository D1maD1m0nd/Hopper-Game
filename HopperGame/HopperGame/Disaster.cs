using System.Runtime.Serialization;


namespace HopperGame
{

    class Disaster
    {
        //Описание катострофы
        [DataMember]
        public string Description;
        //Дополнительное описание катастрофы
        [DataMember]
        public string SubDescription;
        //Остаток насления
        public int RemainderPopulation;
        //Остаток обычных людей
        public int NormalPopulation;
        //Остаток военных
        public int MilitaryPopulation;
        //Остаток зараженных(сюда относятся зомби, мутанты или просто больные)
        public int SickPupulation;

    }
}
