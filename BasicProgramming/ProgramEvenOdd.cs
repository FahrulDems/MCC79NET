namespace BasicProgramming;
public class ProgramEvenOdd
{
    // method void untuk menampilkan menu
    static void Menu() 
    {
        // menampilkan output string 
        Console.WriteLine();
        Console.WriteLine("====================================");
        Console.WriteLine("         MENU GANJIL GENAP          ");
        Console.WriteLine("------------------------------------");
        Console.WriteLine("1. Cek Ganjil Genap");
        Console.WriteLine("2. Print Ganjil Genap (dengan limit)");
        Console.WriteLine("3. Exit");
        Console.WriteLine("------------------------------------");
    }
    // method void untuk menampilkan bilangan genap / ganjil
    // sesuai dengan limit yang diberikan
    // dengan parameter limit dan choice
    static void PrintEvenOdd(int limit, string choice) 
    {
        if (choice != "Genap" && choice != "Ganjil") //jika pilihan yang tidak ganjil atau genap
        { 
            Console.WriteLine("Input pilihan tidak valid!!!");        // menampilkan output string
            return;                                                   // untuk mengembalikan ke pemanggil methods
        }       
        if (limit < 1)                                                 //jika limit dibawah 1 yang berarti tida boleh negatif 
        {            
            Console.WriteLine("Print Bilangan 1 - " + limit + " : ");  // menampilkan output string 
            Console.WriteLine("Input limit tidak valid!!!");           // menampilkan output string  
            return;                                                    // untuk mengembalikan ke pemanggil methods
        }         
        Console.WriteLine("Print Bilangan 1 - " + limit + " : ");      // menampilkan print bilangan dari 1 sampai limit

        // membuat perulangan untuk menampilkan hasil
        // bilangan genap atau ganjil yang telah berhasil dipilih
        for (int i = 1; i <= limit; i++)
        {
            // jika pilihan genap maka i yang telah diloop sampai
            // limit akan ditampilkan dalam bentuk genap 
            // menggunakan modulus 2 dan hasilnya 0
            if (choice == "Genap" && i % 2 == 0)
            {                
                Console.Write(i + ", ");                               // hasil ditampilkan dalam bentuk 1 baris
            }
            // jika pilihan ganjil maka i yang telah diloop sampai
            // limit akan ditampilkan dalam bentuk ganjil 
            // menggunakan modulus 2 dan hasilnya tidak sama 0
            else if (choice == "Ganjil" && i % 2 != 0)
            {               
                Console.Write(i + ", ");                               // hasil ditampilkan dalam bentuk 1 baris
            }
        }
    }
    // method non void yang menggunakan return untuk menampilkan string
    // dengan paramteter input int
    static string EvenOddCheck(int input)
    {
         // jika nilai parameter input dibawah 0
         if (input < 0)
         {              
            return "Invalid Input!!!";                                  // return digunakan untuk menampilkan hasilnya
         }
         // jika nilai parameter input habis dibagi 2
         else if (input % 2 == 0)
         {           
            return "Genap" + "\n====================================";  // return digunakan untuk menampilkan hasilnya
        }
         // jika nilai parameter selain dibawah 0 dan habis dibagi 2
         else
         {            
            return "Ganjil" + "\n===================================="; // return digunakan untuk menampilkan hasilnya
        }
    }
    //method main dimana program dieksekusi pertama kali
    public static void Main()
    {
        bool exit = false;                          // deklrasi variabel exit dalam bentuk boolean dengan nilai false
        while (!exit)                               // membuat loop selama nilai exit bukan true atau false
        {
        // pemanggilan methods menu
        Menu();                     
        Console.Write("Pilihan: ");                         // menampilkan output string        
        int pilihan = Convert.ToInt32(Console.ReadLine());  // input untuk memilih case
            // switch case untuk decision Menu Ganjil Genap
            switch (pilihan)
            {
                // jika input pilihan 1
                case 1:
                    Console.Write("Masukan Bilangan yang ingin di cek : ");  // menampilkan output string
                    // membuat variabel input untuk masukan methods EvenOddCheck
                    int input = Convert.ToInt32(Console.ReadLine());
                    // membuat variabel hasil dari nilai return pada methods EvenOddCheck
                    string hasil = EvenOddCheck(input);                    
                    Console.WriteLine(hasil);                                // menampilkan hasil
                    break;                                                   // untuk mengehentikan eksekusi 
                // jika input pilihan 2
                case 2:                    
                    Console.Write("Pilih (Ganjil/Genap) : ");                // menampilkan output string
                    // membuat variabel pilih untuk input string choice ke methods PrintEvenOdd                   
                    string pilih = Console.ReadLine();                    
                    Console.Write("Masukan Limit : ");                       // menampilkan output string
                    // membuat variabel batas untuk input int limit ke methods PrintEvenOdd
                    int batas = Convert.ToInt32(Console.ReadLine());
                    // memanggil methods PrintEvenOdd
                    PrintEvenOdd(batas,pilih);
                    break;                                                   // untuk mengehentikan eksekusi 
                // jika input pilihan 3
                case 3:
                    // merubah nilai exit menjadi true dan loop akan stop
                    exit = true; 
                    break;                                                   // untuk mengehentikan eksekusi 
                default: // jika pilihan tidak sesuai maka tidak terjadi apa-apa namun dalam case ini akan kemabali loop
                    break;                                                   // untuk mengehentikan eksekusi 
            }

        }
    }
}

