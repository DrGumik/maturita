#include <cstdlib>
#include <windows.h>
#include <iostream>

typedef void(CALLBACK* t_func)(int );
typedef void(CALLBACK* t_func0)();
typedef int(CALLBACK* t_func1)();
typedef void(CALLBACK* t_func2)(int *, int *);
typedef void(CALLBACK* t_func3)(int , int );
typedef int(CALLBACK* t_func4)(int );
typedef bool(CALLBACK* t_func5)(int );

t_func4 OpenDevice;
t_func0 CloseDevice;
t_func0 Version_;
t_func4 ReadAnalogChannel;
t_func2 ReadAllAnalog;
t_func3 OutputAnalogChannel;
t_func3 OutputAllAnalog;
t_func ClearAnalogChannel; 
t_func0 ClearAllAnalog;
t_func SetAnalogChannel; 
t_func0 SetAllAnalog;
t_func WriteAllDigital;
t_func ClearDigitalChannel;
t_func0 ClearAllDigital;
t_func SetDigitalChannel;
t_func0 SetAllDigital;
t_func5 ReadDigitalChannel;
t_func1 ReadAllDigital;

HINSTANCE hDLL;
int foundDLL = 0;
int init();

using namespace std;

int main(int argc, char *argv[])
{
    int CardAddress;
    int dataOut1, dataOut2;
    int dataIn1, dataIn2;
    int h;

   
    h = init();
	if (!h)
	{
		cout << "DLL found" << endl;
		foundDLL = 1;
	}
	else
	{
		cout << "DLL not found" << endl;
	}
	if (foundDLL)
	{
		h = OpenDevice(0);
		if (h == 0)
		{
			cout << "Card 0 opened" << endl;
		}
		else
		{
			cout << "Card not found" << endl;
		}
	}
	if (foundDLL)
	{   
 
        cout << "Press Enter to \"SetAllDigital\"" << endl;
        cin.get();
        SetAllDigital();
        cout << "Press Enter to \"OutputAllDigital 0x55\"" << endl;
        cin.get();
        WriteAllDigital(0x55);

        cout << "Press Enter to \"ReadAllDigital\"" << endl;
        cin.get();

        int i = ReadAllDigital();
        cout << i << endl;
        cout << "Press Enter to \"ReadDigitalChannel 1\"" << endl;
        cin.get();
        bool b = ReadDigitalChannel(1);
        cout << b << endl; 
        cout << "Press Enter to \"ReadDigitalChannel 1\"" << endl;
        cin.get();
        b = ReadDigitalChannel(1);
        cout << b << endl;        
        
        /*        
        cout << "Press Enter to \"ClearAllDigital\"" << endl;
        cin.get();        
        ClearAllDigital();
        
        cout << "Press Enter to \"OutputAllAnalog dataOut1, dataOut2\"" << endl;
        cin.get();
        int h = 0;
        for (int i = 0; i<256; i++)
        {
            OutputAnalogChannel(1, i);
            h = ReadAnalogChannel(1);
                      
        }
    
        int j;
         for (int i = 0; i<3; i++)
        {
            for (j = 0;j < 5;j++) 
            OutputAnalogChannel(1, 0);
            for (j = 0;j < 5;j++) 
            OutputAnalogChannel(1, 255);            
        }    
        
        dataOut1 =80;
        dataOut2 = 255;
        //OutputAllAnalog(dataOut1, dataOut2);
      */
         
        cout << "Press Enter to \"ReadAllAnalog dataIn1, dataIn2\"" << endl;
        cin.get();
        ReadAllAnalog(&dataIn1, &dataIn2);        
            cout << "dataIn1 = " << dataIn1 << endl;
            cout << "dataIn2 = " << dataIn2 << endl;  
                 
        cout << "Press Enter to \"CloseDevices\" and to \"FreeLibrary\"" << endl;
        cin.get();          	
        CloseDevice();
  
        FreeLibrary(hDLL);
    }
    
}

int init()
{
	hDLL = LoadLibrary("k8055d");
	if (hDLL != NULL)
	{
		OpenDevice = (t_func4) GetProcAddress(hDLL, "OpenDevice");
		if (!OpenDevice)		
		{						// handle the error
			FreeLibrary(hDLL);	
			return -2;
		}
		CloseDevice = (t_func0) GetProcAddress(hDLL, "CloseDevice");
		if (!CloseDevice)
		{						// handle the error
			FreeLibrary(hDLL);	
			return -2;
		}
		ReadAnalogChannel = (t_func4) GetProcAddress(hDLL, "ReadAnalogChannel");
		if (!ReadAnalogChannel)
		{						// handle the error
			FreeLibrary(hDLL);	
			return -2;
		}
		ReadAllAnalog = (t_func2) GetProcAddress(hDLL, "ReadAllAnalog");
		if (!ReadAllAnalog)
		{						// handle the error
			FreeLibrary(hDLL);	
			return -2;
		}
		OutputAnalogChannel = (t_func3) GetProcAddress(hDLL, "OutputAnalogChannel");
		if (!OutputAnalogChannel)
		{						// handle the error
			FreeLibrary(hDLL);	
			return -2;
		}
		OutputAllAnalog = (t_func3) GetProcAddress(hDLL, "OutputAllAnalog");
		if (!OutputAllAnalog)		
		{						// handle the error
			FreeLibrary(hDLL);	
			return -2;
		}
		ClearAnalogChannel = (t_func) GetProcAddress(hDLL, "ClearAnalogChannel");
		if (!ClearAnalogChannel)
		{						// handle the error
			FreeLibrary(hDLL);	
			return -2;
		}
		ClearAllAnalog = (t_func0) GetProcAddress(hDLL, "ClearAllAnalog");
		if (!ClearAllAnalog)
		{						// handle the error
			FreeLibrary(hDLL);	
			return -2;
		}
		SetAnalogChannel = (t_func) GetProcAddress(hDLL, "SetAnalogChannel");
		if (!SetAnalogChannel)
		{						// handle the error
			FreeLibrary(hDLL);	
			return -2;
		}
		SetAllAnalog = (t_func0) GetProcAddress(hDLL, "SetAllAnalog");
		if (!SetAllAnalog)
		{						// handle the error
			FreeLibrary(hDLL);	
			return -2;
		}
		WriteAllDigital = (t_func) GetProcAddress(hDLL, "WriteAllDigital");
		if (!WriteAllDigital)
		{						// handle the error
			FreeLibrary(hDLL);	
			return -2;
		}
		ClearDigitalChannel = (t_func) GetProcAddress(hDLL, "ClearDigitalChannel");
		if (!ClearDigitalChannel)
		{						// handle the error
			FreeLibrary(hDLL);	
			return -2;
		}
		ClearAllDigital = (t_func0) GetProcAddress(hDLL, "ClearAllDigital");
		if (!ClearAllDigital)		
		{						// handle the error
			FreeLibrary(hDLL);	
			return -2;
		}
		SetDigitalChannel = (t_func) GetProcAddress(hDLL, "SetDigitalChannel");
		if (!SetDigitalChannel)
		{						// handle the error
			FreeLibrary(hDLL);	
			return -2;
		}
		SetAllDigital = (t_func0) GetProcAddress(hDLL, "SetAllDigital");
		if (!SetAllDigital)		
		{						// handle the error
			FreeLibrary(hDLL);	
			return -2;
		}
		ReadDigitalChannel = (t_func5) GetProcAddress(hDLL, "ReadDigitalChannel");
		if (!ReadDigitalChannel)
		{						// handle the error
			FreeLibrary(hDLL);	
			return -2;
		}
		ReadAllDigital = (t_func1) GetProcAddress(hDLL, "ReadAllDigital");
		if (!ReadAllDigital)
		{						// handle the error
			FreeLibrary(hDLL);	
			return -2;
		}
		Version_ = (t_func0) GetProcAddress(hDLL, "Version");
		if (!Version_)
		{						// handle the error
			FreeLibrary(hDLL);	
			return -2;
		}
		return 0;				// ok
	}       
	return -1;					// error load DLL
}
