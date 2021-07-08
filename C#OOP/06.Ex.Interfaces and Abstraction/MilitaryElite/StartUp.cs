using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<ISoldier> soldiers = new List<ISoldier>();
            string[] input = Console.ReadLine().Split();
            while (input[0].ToLower() != "end")
            {
                string title = input[0].ToLower();
                int id = int.Parse(input[1]);
                string firstName = input[2];
                string lastName = input[3];
                if (title == "private")
                {
                    decimal salary = decimal.Parse(input[4]);
                    Private @private = new Private(id, firstName, lastName, salary);
                    soldiers.Add(@private);
                }
                else if (title == "lieutenantgeneral")
                {
                    decimal salary = decimal.Parse(input[4]);
                    List<IPrivate> privates = GetLieutenantGeneralPrivates(input.Skip(5).ToArray(), soldiers);
                    LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                    soldiers.Add(lieutenantGeneral);
                }
                else if (title == "engineer")
                {
                    decimal salary = decimal.Parse(input[4]);
                    string corps = input[5];
                    List<IRepair> repairs = GetEngineerRepairs(input.Skip(6).ToArray());
                    if (corps == "Airforces")
                    {
                        Engineer engineer = new Engineer(id, firstName, lastName, salary, SoldiersCorpsEnum.Airforces, repairs);
                        soldiers.Add(engineer);
                    }
                    else if (corps == "Marines")
                    {
                        Engineer engineer = new Engineer(id, firstName, lastName, salary, SoldiersCorpsEnum.Marines, repairs);
                        soldiers.Add(engineer);
                    }
                }
                else if (title == "commando")
                {
                    decimal salary = decimal.Parse(input[4]);
                    string corps = input[5];
                    List<IMission> missions = GetCommandoMissions(input.Skip(6).ToArray());
                    if (corps == "Airforces")
                    {
                        Commando commando = new Commando(id, firstName, lastName, salary, SoldiersCorpsEnum.Airforces, missions);
                        soldiers.Add(commando);
                    }
                    else if (corps == "Marines")
                    {
                        Commando commando = new Commando(id, firstName, lastName, salary, SoldiersCorpsEnum.Marines, missions);
                        soldiers.Add(commando);
                    }
                }
                else if (title == "spy")
                {
                    int codeNumber = int.Parse(input[4]);
                    Spy spy = new Spy(id, firstName, lastName, codeNumber);
                    soldiers.Add(spy);
                }
                input = Console.ReadLine().Split();
            }
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
        public static List<IPrivate> GetLieutenantGeneralPrivates(string[] ids, List<ISoldier> soldiers)
        {
            List<IPrivate> privates = new List<IPrivate>();
            foreach (var id in ids)
            {
                IPrivate @private = (Private)soldiers.FirstOrDefault(x => x.Id == int.Parse(id));
                if (@private != null)
                {
                    privates.Add(@private);
                }
            }
            return privates;
        }
        public static List<IRepair> GetEngineerRepairs(string[] repairs)
        {
            List<IRepair> result = new List<IRepair>();
            for (int i = 0; i < repairs.Length - 1; i += 2)
            {
                string partName = repairs[i];
                int hoursWorked = int.Parse(repairs[i + 1]);
                Repair repair = new Repair(partName, hoursWorked);
                result.Add(repair);
            }
            return result;
        }
        public static List<IMission> GetCommandoMissions(string[] missions)
        {
            List<IMission> result = new List<IMission>();
            for (int i = 0; i < missions.Length - 1; i += 2)
            {
                string codeName = missions[i];
                string state = missions[i + 1];
                if (state == "inProgress")
                {
                    Missions mission = new Missions(codeName, MissionStateEnum.inProgress);
                    result.Add(mission);
                }
                else if (state == "Finished")
                {
                    Missions mission = new Missions(codeName, MissionStateEnum.Finished);
                    result.Add(mission);
                }
            }
            return result;
        }

    }
}
