using System;
using System.Linq;
    class Program
    {
        public class Data
        {
            public int Start { get; set; }
            public int End { get; set; }
        }

        static void Main(string[] args)
        {
            int type = int.Parse(Console.ReadLine());
            Data[] data = new Data[type];

            for (int i = 0; i < data.Length; i++)
            {
                //입력받은 String 배열을 int형식 배열로 변환
                int[] Time = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));

                //Data 클래스에 관련값 저장
                data[i] = new Data { Start = Time[0], End = Time[1] };
            }

            //클래스 배열 End값 오름차순으로 정렬후, Start기준으로 오름차순 재정렬 진행
            var result = data.OrderBy(i => i.End).ThenBy(i => i.Start).Select(i => i).ToArray();

            int count = 0; //회의실 개수
            int prev_end_time = 0; //끝나는 시간

            for (int i = 0; i < type; i++)
            {
                // 직전 종료시간이 다음 회의 시작 시간보다 작거나 같다면 갱신 
                if (prev_end_time <= result[i].Start)
                {
                    prev_end_time = result[i].End;
                    count++;
                }
            }

            Console.WriteLine(count);

            Console.ReadLine();
        }

    }