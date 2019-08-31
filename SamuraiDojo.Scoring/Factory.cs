using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Scoring.Auditors;
using SamuraiDojo.Scoring.Interfaces;

namespace SamuraiDojo.Scoring
{

    public static class Factory
    {
        private static IDictionary<Auditor, Type> auditors;
        private static IDictionary<Type, Type> typeMap;

        static Factory()
        {
            auditors = new Dictionary<Auditor, Type>();
            typeMap = new Dictionary<Type, Type>();

            Bind<IRankCalculator>(typeof(RankCalculator));
            BindAuditor<DojoAuditor>(Auditor.DOJO);
            BindAuditor<TestAuditor>(Auditor.TEST);
        }

        public static void Bind<T>(Type type)
        {
            if (!typeof(T).IsInterface)
                throw new InvalidCastException("Type parameter for Factory.Register<T>(Type type) must be an interface.");

            typeMap.Add(typeof(T), type);
        }

        public static void BindAuditor<T>(Auditor auditor) where T : IAuditor
        {
            auditors.Add(auditor, typeof(T));
        }

        public static IAuditor New(Auditor auditor)
        {
            Type type = auditors[auditor];
            IAuditor instance = (IAuditor)Activator.CreateInstance(type);

            return instance;
        }

        public static T New<T>()
        {
            if (!typeof(T).IsInterface)
                throw new InvalidCastException("Type parameter for Factory.New<T>() must be an interface.");

            T instance = (T)Activator.CreateInstance(typeMap[typeof(T)]);
            return instance;
        }
    }
    
    public enum Auditor
    {
        DOJO,
        TEST
    }
}
