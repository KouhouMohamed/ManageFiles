// See https://aka.ms/new-console-template for more information

string FileDirectory = @"C:\Users\DELL\source\repos\ManageFiles\ManageFiles\data\notes\";
string ResumeDirectory = @"C:\Users\DELL\source\repos\ManageFiles\ManageFiles\data\resume\";
string FileName = "note";
string ResumeFileName = Path.Combine(ResumeDirectory,"resume-" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt");

int count = 1;

if (!Directory.Exists(ResumeDirectory)) Directory.CreateDirectory(ResumeDirectory);

using (var writer = File.CreateText(ResumeFileName))
{
    string filename = FileDirectory + FileName + count + ".txt";
    string data = string.Empty;

    while (File.Exists(filename))
    {   
        
        count++;
        using (var reader = File.OpenText(filename))
        {
            data = reader.ReadToEnd();
            await writer.WriteAsync(data+"\n");
            filename = FileDirectory + FileName + count + ".txt";

        }

    }
    
}
