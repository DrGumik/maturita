#pragma once


namespace K8055Demo {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace System::Runtime::InteropServices; 

	/// <summary>
	/// Summary for Form1
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	internal: System::Windows::Forms::Label^  Label5;
	protected: 
	internal: System::Windows::Forms::GroupBox^  GroupBox7;
	internal: System::Windows::Forms::VScrollBar^  VScrollBar2;
	internal: System::Windows::Forms::CheckBox^  CheckBox16;
	internal: System::Windows::Forms::GroupBox^  GroupBox6;
	internal: System::Windows::Forms::Label^  Label4;
	internal: System::Windows::Forms::VScrollBar^  VScrollBar1;
	internal: System::Windows::Forms::Button^  Button7;
	internal: System::Windows::Forms::Button^  Button5;
	internal: System::Windows::Forms::VScrollBar^  VScrollBar3;
	internal: System::Windows::Forms::GroupBox^  GroupBox9;
	internal: System::Windows::Forms::Label^  Label7;
	internal: System::Windows::Forms::VScrollBar^  VScrollBar4;
	internal: System::Windows::Forms::GroupBox^  GroupBox8;
	internal: System::Windows::Forms::Label^  Label6;
	internal: System::Windows::Forms::Button^  Button6;
	internal: System::Windows::Forms::RadioButton^  RadioButton4;
	internal: System::Windows::Forms::RadioButton^  RadioButton3;
	internal: System::Windows::Forms::CheckBox^  CheckBox8;
	internal: System::Windows::Forms::CheckBox^  CheckBox7;
	internal: System::Windows::Forms::CheckBox^  CheckBox6;
	internal: System::Windows::Forms::CheckBox^  CheckBox5;
	internal: System::Windows::Forms::CheckBox^  CheckBox4;
	internal: System::Windows::Forms::GroupBox^  GroupBox1;
	internal: System::Windows::Forms::Timer^  Timer2;
	internal: System::Windows::Forms::Button^  Button4;
	internal: System::Windows::Forms::RadioButton^  RadioButton2;
	internal: System::Windows::Forms::RadioButton^  RadioButton1;
	internal: System::Windows::Forms::Label^  Label2;
	internal: System::Windows::Forms::Button^  Button2;
	internal: System::Windows::Forms::TextBox^  TextBox1;
	internal: System::Windows::Forms::CheckBox^  CheckBox2;
	internal: System::Windows::Forms::CheckBox^  CheckBox1;
	internal: System::Windows::Forms::RadioButton^  RadioButton5;
	internal: System::Windows::Forms::RadioButton^  RadioButton7;
	internal: System::Windows::Forms::CheckBox^  CheckBox14;
	internal: System::Windows::Forms::CheckBox^  CheckBox12;
	internal: System::Windows::Forms::Button^  Button1;
	internal: System::Windows::Forms::RadioButton^  RadioButton6;
	internal: System::Windows::Forms::GroupBox^  GroupBox5;
	internal: System::Windows::Forms::RadioButton^  RadioButton8;
	internal: System::Windows::Forms::Label^  Label3;
	internal: System::Windows::Forms::Button^  Button3;
	internal: System::Windows::Forms::TextBox^  TextBox2;
	internal: System::Windows::Forms::CheckBox^  CheckBox3;
	internal: System::Windows::Forms::Label^  Label1;
	internal: System::Windows::Forms::CheckBox^  CheckBox15;
	internal: System::Windows::Forms::CheckBox^  CheckBox13;
	internal: System::Windows::Forms::CheckBox^  CheckBox11;
	internal: System::Windows::Forms::Label^  Label9;
	internal: System::Windows::Forms::Button^  Button8;
	internal: System::Windows::Forms::GroupBox^  GroupBox10;
	internal: System::Windows::Forms::Button^  Button9;
	internal: System::Windows::Forms::Label^  Label8;
	internal: System::Windows::Forms::RadioButton^  RadioButton12;
	internal: System::Windows::Forms::RadioButton^  RadioButton11;
	internal: System::Windows::Forms::RadioButton^  RadioButton10;
	internal: System::Windows::Forms::RadioButton^  RadioButton9;
	internal: System::Windows::Forms::GroupBox^  GroupBox3;
	internal: System::Windows::Forms::Timer^  Timer1;
	internal: System::Windows::Forms::CheckBox^  CheckBox9;
	internal: System::Windows::Forms::GroupBox^  GroupBox2;
	internal: System::Windows::Forms::CheckBox^  CheckBox10;
	internal: System::Windows::Forms::GroupBox^  GroupBox4;


	internal: 
	private: System::ComponentModel::IContainer^  components;
	internal: 

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>


#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->components = (gcnew System::ComponentModel::Container());
			this->Label5 = (gcnew System::Windows::Forms::Label());
			this->GroupBox7 = (gcnew System::Windows::Forms::GroupBox());
			this->VScrollBar2 = (gcnew System::Windows::Forms::VScrollBar());
			this->CheckBox16 = (gcnew System::Windows::Forms::CheckBox());
			this->GroupBox6 = (gcnew System::Windows::Forms::GroupBox());
			this->Label4 = (gcnew System::Windows::Forms::Label());
			this->VScrollBar1 = (gcnew System::Windows::Forms::VScrollBar());
			this->Button7 = (gcnew System::Windows::Forms::Button());
			this->Button5 = (gcnew System::Windows::Forms::Button());
			this->VScrollBar3 = (gcnew System::Windows::Forms::VScrollBar());
			this->GroupBox9 = (gcnew System::Windows::Forms::GroupBox());
			this->Label7 = (gcnew System::Windows::Forms::Label());
			this->VScrollBar4 = (gcnew System::Windows::Forms::VScrollBar());
			this->GroupBox8 = (gcnew System::Windows::Forms::GroupBox());
			this->Label6 = (gcnew System::Windows::Forms::Label());
			this->Button6 = (gcnew System::Windows::Forms::Button());
			this->RadioButton4 = (gcnew System::Windows::Forms::RadioButton());
			this->RadioButton3 = (gcnew System::Windows::Forms::RadioButton());
			this->CheckBox8 = (gcnew System::Windows::Forms::CheckBox());
			this->CheckBox7 = (gcnew System::Windows::Forms::CheckBox());
			this->CheckBox6 = (gcnew System::Windows::Forms::CheckBox());
			this->CheckBox5 = (gcnew System::Windows::Forms::CheckBox());
			this->CheckBox4 = (gcnew System::Windows::Forms::CheckBox());
			this->GroupBox1 = (gcnew System::Windows::Forms::GroupBox());
			this->Timer2 = (gcnew System::Windows::Forms::Timer(this->components));
			this->Button4 = (gcnew System::Windows::Forms::Button());
			this->RadioButton2 = (gcnew System::Windows::Forms::RadioButton());
			this->RadioButton1 = (gcnew System::Windows::Forms::RadioButton());
			this->Label2 = (gcnew System::Windows::Forms::Label());
			this->Button2 = (gcnew System::Windows::Forms::Button());
			this->TextBox1 = (gcnew System::Windows::Forms::TextBox());
			this->CheckBox2 = (gcnew System::Windows::Forms::CheckBox());
			this->CheckBox1 = (gcnew System::Windows::Forms::CheckBox());
			this->RadioButton5 = (gcnew System::Windows::Forms::RadioButton());
			this->RadioButton7 = (gcnew System::Windows::Forms::RadioButton());
			this->CheckBox14 = (gcnew System::Windows::Forms::CheckBox());
			this->CheckBox12 = (gcnew System::Windows::Forms::CheckBox());
			this->Button1 = (gcnew System::Windows::Forms::Button());
			this->RadioButton6 = (gcnew System::Windows::Forms::RadioButton());
			this->GroupBox5 = (gcnew System::Windows::Forms::GroupBox());
			this->RadioButton8 = (gcnew System::Windows::Forms::RadioButton());
			this->Label3 = (gcnew System::Windows::Forms::Label());
			this->Button3 = (gcnew System::Windows::Forms::Button());
			this->TextBox2 = (gcnew System::Windows::Forms::TextBox());
			this->CheckBox3 = (gcnew System::Windows::Forms::CheckBox());
			this->Label1 = (gcnew System::Windows::Forms::Label());
			this->CheckBox15 = (gcnew System::Windows::Forms::CheckBox());
			this->CheckBox13 = (gcnew System::Windows::Forms::CheckBox());
			this->CheckBox11 = (gcnew System::Windows::Forms::CheckBox());
			this->Label9 = (gcnew System::Windows::Forms::Label());
			this->Button8 = (gcnew System::Windows::Forms::Button());
			this->GroupBox10 = (gcnew System::Windows::Forms::GroupBox());
			this->Button9 = (gcnew System::Windows::Forms::Button());
			this->Label8 = (gcnew System::Windows::Forms::Label());
			this->RadioButton12 = (gcnew System::Windows::Forms::RadioButton());
			this->RadioButton11 = (gcnew System::Windows::Forms::RadioButton());
			this->RadioButton10 = (gcnew System::Windows::Forms::RadioButton());
			this->RadioButton9 = (gcnew System::Windows::Forms::RadioButton());
			this->GroupBox3 = (gcnew System::Windows::Forms::GroupBox());
			this->Timer1 = (gcnew System::Windows::Forms::Timer(this->components));
			this->CheckBox9 = (gcnew System::Windows::Forms::CheckBox());
			this->GroupBox2 = (gcnew System::Windows::Forms::GroupBox());
			this->CheckBox10 = (gcnew System::Windows::Forms::CheckBox());
			this->GroupBox4 = (gcnew System::Windows::Forms::GroupBox());
			this->GroupBox7->SuspendLayout();
			this->GroupBox6->SuspendLayout();
			this->GroupBox9->SuspendLayout();
			this->GroupBox8->SuspendLayout();
			this->GroupBox1->SuspendLayout();
			this->GroupBox5->SuspendLayout();
			this->GroupBox10->SuspendLayout();
			this->GroupBox3->SuspendLayout();
			this->GroupBox2->SuspendLayout();
			this->GroupBox4->SuspendLayout();
			this->SuspendLayout();
			// 
			// Label5
			// 
			this->Label5->Location = System::Drawing::Point(12, 276);
			this->Label5->Name = L"Label5";
			this->Label5->Size = System::Drawing::Size(28, 16);
			this->Label5->TabIndex = 14;
			this->Label5->Text = L" 00";
			// 
			// GroupBox7
			// 
			this->GroupBox7->Controls->Add(this->Label5);
			this->GroupBox7->Controls->Add(this->VScrollBar2);
			this->GroupBox7->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(0)));
			this->GroupBox7->Location = System::Drawing::Point(192, 8);
			this->GroupBox7->Name = L"GroupBox7";
			this->GroupBox7->Size = System::Drawing::Size(44, 300);
			this->GroupBox7->TabIndex = 67;
			this->GroupBox7->TabStop = false;
			this->GroupBox7->Text = L"DA2";
			// 
			// VScrollBar2
			// 
			this->VScrollBar2->LargeChange = 1;
			this->VScrollBar2->Location = System::Drawing::Point(14, 20);
			this->VScrollBar2->Maximum = 255;
			this->VScrollBar2->Name = L"VScrollBar2";
			this->VScrollBar2->Size = System::Drawing::Size(16, 252);
			this->VScrollBar2->TabIndex = 13;
			this->VScrollBar2->Value = 255;
			this->VScrollBar2->Scroll += gcnew System::Windows::Forms::ScrollEventHandler(this, &Form1::VScrollBar2_Scroll);
			// 
			// CheckBox16
			// 
			this->CheckBox16->Location = System::Drawing::Point(230, 17);
			this->CheckBox16->Name = L"CheckBox16";
			this->CheckBox16->Size = System::Drawing::Size(26, 15);
			this->CheckBox16->TabIndex = 12;
			this->CheckBox16->Text = L"8";
			this->CheckBox16->UseVisualStyleBackColor = true;
			this->CheckBox16->CheckedChanged += gcnew System::EventHandler(this, &Form1::CheckBox16_CheckedChanged);
			// 
			// GroupBox6
			// 
			this->GroupBox6->Controls->Add(this->Label4);
			this->GroupBox6->Controls->Add(this->VScrollBar1);
			this->GroupBox6->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(0)));
			this->GroupBox6->Location = System::Drawing::Point(144, 8);
			this->GroupBox6->Name = L"GroupBox6";
			this->GroupBox6->Size = System::Drawing::Size(44, 300);
			this->GroupBox6->TabIndex = 66;
			this->GroupBox6->TabStop = false;
			this->GroupBox6->Text = L"DA1";
			// 
			// Label4
			// 
			this->Label4->Location = System::Drawing::Point(12, 276);
			this->Label4->Name = L"Label4";
			this->Label4->Size = System::Drawing::Size(28, 16);
			this->Label4->TabIndex = 14;
			this->Label4->Text = L" 00";
			// 
			// VScrollBar1
			// 
			this->VScrollBar1->LargeChange = 1;
			this->VScrollBar1->Location = System::Drawing::Point(14, 20);
			this->VScrollBar1->Maximum = 255;
			this->VScrollBar1->Name = L"VScrollBar1";
			this->VScrollBar1->Size = System::Drawing::Size(16, 252);
			this->VScrollBar1->TabIndex = 13;
			this->VScrollBar1->Value = 255;
			this->VScrollBar1->Scroll += gcnew System::Windows::Forms::ScrollEventHandler(this, &Form1::VScrollBar1_Scroll);
			// 
			// Button7
			// 
			this->Button7->Location = System::Drawing::Point(12, 224);
			this->Button7->Name = L"Button7";
			this->Button7->Size = System::Drawing::Size(108, 24);
			this->Button7->TabIndex = 64;
			this->Button7->Text = L"Set All Analog";
			this->Button7->Click += gcnew System::EventHandler(this, &Form1::Button7_Click);
			// 
			// Button5
			// 
			this->Button5->Location = System::Drawing::Point(12, 194);
			this->Button5->Name = L"Button5";
			this->Button5->Size = System::Drawing::Size(108, 24);
			this->Button5->TabIndex = 63;
			this->Button5->Text = L"Clear All Digital";
			this->Button5->Click += gcnew System::EventHandler(this, &Form1::Button5_Click);
			// 
			// VScrollBar3
			// 
			this->VScrollBar3->LargeChange = 1;
			this->VScrollBar3->Location = System::Drawing::Point(14, 20);
			this->VScrollBar3->Maximum = 255;
			this->VScrollBar3->Name = L"VScrollBar3";
			this->VScrollBar3->Size = System::Drawing::Size(16, 252);
			this->VScrollBar3->TabIndex = 13;
			this->VScrollBar3->Value = 255;
			// 
			// GroupBox9
			// 
			this->GroupBox9->Controls->Add(this->Label7);
			this->GroupBox9->Controls->Add(this->VScrollBar4);
			this->GroupBox9->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(0)));
			this->GroupBox9->Location = System::Drawing::Point(304, 8);
			this->GroupBox9->Name = L"GroupBox9";
			this->GroupBox9->Size = System::Drawing::Size(44, 300);
			this->GroupBox9->TabIndex = 69;
			this->GroupBox9->TabStop = false;
			this->GroupBox9->Text = L"AD2";
			// 
			// Label7
			// 
			this->Label7->Location = System::Drawing::Point(12, 276);
			this->Label7->Name = L"Label7";
			this->Label7->Size = System::Drawing::Size(28, 16);
			this->Label7->TabIndex = 14;
			this->Label7->Text = L" 00";
			// 
			// VScrollBar4
			// 
			this->VScrollBar4->LargeChange = 1;
			this->VScrollBar4->Location = System::Drawing::Point(14, 20);
			this->VScrollBar4->Maximum = 255;
			this->VScrollBar4->Name = L"VScrollBar4";
			this->VScrollBar4->Size = System::Drawing::Size(16, 252);
			this->VScrollBar4->TabIndex = 13;
			this->VScrollBar4->Value = 255;
			// 
			// GroupBox8
			// 
			this->GroupBox8->Controls->Add(this->Label6);
			this->GroupBox8->Controls->Add(this->VScrollBar3);
			this->GroupBox8->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(0)));
			this->GroupBox8->Location = System::Drawing::Point(256, 8);
			this->GroupBox8->Name = L"GroupBox8";
			this->GroupBox8->Size = System::Drawing::Size(44, 300);
			this->GroupBox8->TabIndex = 68;
			this->GroupBox8->TabStop = false;
			this->GroupBox8->Text = L"AD1";
			// 
			// Label6
			// 
			this->Label6->Location = System::Drawing::Point(12, 276);
			this->Label6->Name = L"Label6";
			this->Label6->Size = System::Drawing::Size(28, 16);
			this->Label6->TabIndex = 14;
			this->Label6->Text = L" 00";
			// 
			// Button6
			// 
			this->Button6->Location = System::Drawing::Point(12, 254);
			this->Button6->Name = L"Button6";
			this->Button6->Size = System::Drawing::Size(108, 24);
			this->Button6->TabIndex = 65;
			this->Button6->Text = L"Clear All Analog";
			this->Button6->Click += gcnew System::EventHandler(this, &Form1::Button6_Click);
			// 
			// RadioButton4
			// 
			this->RadioButton4->AutoSize = true;
			this->RadioButton4->Location = System::Drawing::Point(9, 159);
			this->RadioButton4->Name = L"RadioButton4";
			this->RadioButton4->Size = System::Drawing::Size(62, 17);
			this->RadioButton4->TabIndex = 6;
			this->RadioButton4->Text = L"1000ms";
			this->RadioButton4->UseVisualStyleBackColor = true;
			this->RadioButton4->CheckedChanged += gcnew System::EventHandler(this, &Form1::RadioButton4_CheckedChanged);
			// 
			// RadioButton3
			// 
			this->RadioButton3->AutoSize = true;
			this->RadioButton3->Location = System::Drawing::Point(9, 136);
			this->RadioButton3->Name = L"RadioButton3";
			this->RadioButton3->Size = System::Drawing::Size(50, 17);
			this->RadioButton3->TabIndex = 5;
			this->RadioButton3->Text = L"10ms";
			this->RadioButton3->UseVisualStyleBackColor = true;
			this->RadioButton3->CheckedChanged += gcnew System::EventHandler(this, &Form1::RadioButton3_CheckedChanged);
			// 
			// CheckBox8
			// 
			this->CheckBox8->Location = System::Drawing::Point(134, 17);
			this->CheckBox8->Name = L"CheckBox8";
			this->CheckBox8->Size = System::Drawing::Size(26, 15);
			this->CheckBox8->TabIndex = 4;
			this->CheckBox8->Text = L"5";
			this->CheckBox8->UseVisualStyleBackColor = true;
			// 
			// CheckBox7
			// 
			this->CheckBox7->Location = System::Drawing::Point(102, 17);
			this->CheckBox7->Name = L"CheckBox7";
			this->CheckBox7->Size = System::Drawing::Size(26, 15);
			this->CheckBox7->TabIndex = 3;
			this->CheckBox7->Text = L"4";
			this->CheckBox7->UseVisualStyleBackColor = true;
			// 
			// CheckBox6
			// 
			this->CheckBox6->Location = System::Drawing::Point(70, 17);
			this->CheckBox6->Name = L"CheckBox6";
			this->CheckBox6->Size = System::Drawing::Size(26, 15);
			this->CheckBox6->TabIndex = 2;
			this->CheckBox6->Text = L"3";
			this->CheckBox6->UseVisualStyleBackColor = true;
			// 
			// CheckBox5
			// 
			this->CheckBox5->Location = System::Drawing::Point(38, 17);
			this->CheckBox5->Name = L"CheckBox5";
			this->CheckBox5->Size = System::Drawing::Size(26, 15);
			this->CheckBox5->TabIndex = 1;
			this->CheckBox5->Text = L"2";
			this->CheckBox5->UseVisualStyleBackColor = true;
			// 
			// CheckBox4
			// 
			this->CheckBox4->Location = System::Drawing::Point(6, 17);
			this->CheckBox4->Name = L"CheckBox4";
			this->CheckBox4->Size = System::Drawing::Size(26, 15);
			this->CheckBox4->TabIndex = 0;
			this->CheckBox4->Text = L"1";
			this->CheckBox4->UseVisualStyleBackColor = true;
			// 
			// GroupBox1
			// 
			this->GroupBox1->Controls->Add(this->CheckBox8);
			this->GroupBox1->Controls->Add(this->CheckBox7);
			this->GroupBox1->Controls->Add(this->CheckBox6);
			this->GroupBox1->Controls->Add(this->CheckBox5);
			this->GroupBox1->Controls->Add(this->CheckBox4);
			this->GroupBox1->Location = System::Drawing::Point(368, 8);
			this->GroupBox1->Name = L"GroupBox1";
			this->GroupBox1->Size = System::Drawing::Size(172, 40);
			this->GroupBox1->TabIndex = 55;
			this->GroupBox1->TabStop = false;
			this->GroupBox1->Text = L"Inputs";
			// 
			// Timer2
			// 
			this->Timer2->Tick += gcnew System::EventHandler(this, &Form1::Timer2_Tick);
			// 
			// Button4
			// 
			this->Button4->Location = System::Drawing::Point(12, 164);
			this->Button4->Name = L"Button4";
			this->Button4->Size = System::Drawing::Size(108, 24);
			this->Button4->TabIndex = 62;
			this->Button4->Text = L"Set All Digital";
			this->Button4->Click += gcnew System::EventHandler(this, &Form1::Button4_Click);
			// 
			// RadioButton2
			// 
			this->RadioButton2->AutoSize = true;
			this->RadioButton2->Checked = true;
			this->RadioButton2->Location = System::Drawing::Point(9, 113);
			this->RadioButton2->Name = L"RadioButton2";
			this->RadioButton2->Size = System::Drawing::Size(44, 17);
			this->RadioButton2->TabIndex = 4;
			this->RadioButton2->TabStop = true;
			this->RadioButton2->Text = L"2ms";
			this->RadioButton2->UseVisualStyleBackColor = true;
			this->RadioButton2->CheckedChanged += gcnew System::EventHandler(this, &Form1::RadioButton2_CheckedChanged);
			// 
			// RadioButton1
			// 
			this->RadioButton1->AutoSize = true;
			this->RadioButton1->Location = System::Drawing::Point(9, 90);
			this->RadioButton1->Name = L"RadioButton1";
			this->RadioButton1->Size = System::Drawing::Size(44, 17);
			this->RadioButton1->TabIndex = 3;
			this->RadioButton1->Text = L"0ms";
			this->RadioButton1->UseVisualStyleBackColor = true;
			this->RadioButton1->CheckedChanged += gcnew System::EventHandler(this, &Form1::RadioButton1_CheckedChanged);
			// 
			// Label2
			// 
			this->Label2->Location = System::Drawing::Point(6, 71);
			this->Label2->Name = L"Label2";
			this->Label2->Size = System::Drawing::Size(104, 16);
			this->Label2->TabIndex = 2;
			this->Label2->Text = L"Debounce Time";
			// 
			// Button2
			// 
			this->Button2->Location = System::Drawing::Point(6, 44);
			this->Button2->Name = L"Button2";
			this->Button2->Size = System::Drawing::Size(104, 24);
			this->Button2->TabIndex = 1;
			this->Button2->Text = L"Reset";
			this->Button2->Click += gcnew System::EventHandler(this, &Form1::Button2_Click);
			// 
			// TextBox1
			// 
			this->TextBox1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(0)));
			this->TextBox1->Location = System::Drawing::Point(6, 19);
			this->TextBox1->Name = L"TextBox1";
			this->TextBox1->Size = System::Drawing::Size(104, 20);
			this->TextBox1->TabIndex = 0;
			this->TextBox1->Text = L"0";
			// 
			// CheckBox2
			// 
			this->CheckBox2->Checked = true;
			this->CheckBox2->CheckState = System::Windows::Forms::CheckState::Checked;
			this->CheckBox2->Location = System::Drawing::Point(56, 20);
			this->CheckBox2->Name = L"CheckBox2";
			this->CheckBox2->Size = System::Drawing::Size(48, 16);
			this->CheckBox2->TabIndex = 1;
			this->CheckBox2->Text = L"SK6";
			// 
			// CheckBox1
			// 
			this->CheckBox1->Checked = true;
			this->CheckBox1->CheckState = System::Windows::Forms::CheckState::Checked;
			this->CheckBox1->Cursor = System::Windows::Forms::Cursors::Default;
			this->CheckBox1->Location = System::Drawing::Point(8, 20);
			this->CheckBox1->Name = L"CheckBox1";
			this->CheckBox1->Size = System::Drawing::Size(48, 16);
			this->CheckBox1->TabIndex = 0;
			this->CheckBox1->Text = L"SK5";
			// 
			// RadioButton5
			// 
			this->RadioButton5->AutoSize = true;
			this->RadioButton5->Location = System::Drawing::Point(9, 90);
			this->RadioButton5->Name = L"RadioButton5";
			this->RadioButton5->Size = System::Drawing::Size(44, 17);
			this->RadioButton5->TabIndex = 6;
			this->RadioButton5->Text = L"0ms";
			this->RadioButton5->UseVisualStyleBackColor = true;
			this->RadioButton5->CheckedChanged += gcnew System::EventHandler(this, &Form1::RadioButton5_CheckedChanged);
			// 
			// RadioButton7
			// 
			this->RadioButton7->AutoSize = true;
			this->RadioButton7->Location = System::Drawing::Point(9, 136);
			this->RadioButton7->Name = L"RadioButton7";
			this->RadioButton7->Size = System::Drawing::Size(50, 17);
			this->RadioButton7->TabIndex = 4;
			this->RadioButton7->Text = L"10ms";
			this->RadioButton7->UseVisualStyleBackColor = true;
			this->RadioButton7->CheckedChanged += gcnew System::EventHandler(this, &Form1::RadioButton7_CheckedChanged);
			// 
			// CheckBox14
			// 
			this->CheckBox14->Location = System::Drawing::Point(166, 17);
			this->CheckBox14->Name = L"CheckBox14";
			this->CheckBox14->Size = System::Drawing::Size(26, 15);
			this->CheckBox14->TabIndex = 10;
			this->CheckBox14->Text = L"6";
			this->CheckBox14->UseVisualStyleBackColor = true;
			this->CheckBox14->CheckedChanged += gcnew System::EventHandler(this, &Form1::CheckBox14_CheckedChanged);
			// 
			// CheckBox12
			// 
			this->CheckBox12->Location = System::Drawing::Point(102, 17);
			this->CheckBox12->Name = L"CheckBox12";
			this->CheckBox12->Size = System::Drawing::Size(26, 15);
			this->CheckBox12->TabIndex = 8;
			this->CheckBox12->Text = L"4";
			this->CheckBox12->UseVisualStyleBackColor = true;
			this->CheckBox12->CheckedChanged += gcnew System::EventHandler(this, &Form1::CheckBox12_CheckedChanged);
			// 
			// Button1
			// 
			this->Button1->FlatStyle = System::Windows::Forms::FlatStyle::System;
			this->Button1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(0)));
			this->Button1->Location = System::Drawing::Point(12, 58);
			this->Button1->Name = L"Button1";
			this->Button1->Size = System::Drawing::Size(108, 24);
			this->Button1->TabIndex = 58;
			this->Button1->Text = L"Connect";
			this->Button1->Click += gcnew System::EventHandler(this, &Form1::Button1_Click);
			// 
			// RadioButton6
			// 
			this->RadioButton6->AutoSize = true;
			this->RadioButton6->Checked = true;
			this->RadioButton6->Location = System::Drawing::Point(9, 113);
			this->RadioButton6->Name = L"RadioButton6";
			this->RadioButton6->Size = System::Drawing::Size(44, 17);
			this->RadioButton6->TabIndex = 5;
			this->RadioButton6->TabStop = true;
			this->RadioButton6->Text = L"2ms";
			this->RadioButton6->UseVisualStyleBackColor = true;
			this->RadioButton6->CheckedChanged += gcnew System::EventHandler(this, &Form1::RadioButton6_CheckedChanged);
			// 
			// GroupBox5
			// 
			this->GroupBox5->Controls->Add(this->RadioButton5);
			this->GroupBox5->Controls->Add(this->RadioButton6);
			this->GroupBox5->Controls->Add(this->RadioButton7);
			this->GroupBox5->Controls->Add(this->RadioButton8);
			this->GroupBox5->Controls->Add(this->Label3);
			this->GroupBox5->Controls->Add(this->Button3);
			this->GroupBox5->Controls->Add(this->TextBox2);
			this->GroupBox5->Location = System::Drawing::Point(511, 124);
			this->GroupBox5->Name = L"GroupBox5";
			this->GroupBox5->Size = System::Drawing::Size(117, 184);
			this->GroupBox5->TabIndex = 70;
			this->GroupBox5->TabStop = false;
			this->GroupBox5->Text = L"Counter2";
			// 
			// RadioButton8
			// 
			this->RadioButton8->AutoSize = true;
			this->RadioButton8->Location = System::Drawing::Point(9, 159);
			this->RadioButton8->Name = L"RadioButton8";
			this->RadioButton8->Size = System::Drawing::Size(62, 17);
			this->RadioButton8->TabIndex = 3;
			this->RadioButton8->Text = L"1000ms";
			this->RadioButton8->UseVisualStyleBackColor = true;
			this->RadioButton8->CheckedChanged += gcnew System::EventHandler(this, &Form1::RadioButton8_CheckedChanged);
			// 
			// Label3
			// 
			this->Label3->Location = System::Drawing::Point(6, 71);
			this->Label3->Name = L"Label3";
			this->Label3->Size = System::Drawing::Size(104, 16);
			this->Label3->TabIndex = 2;
			this->Label3->Text = L"Debounce Time";
			// 
			// Button3
			// 
			this->Button3->Location = System::Drawing::Point(6, 44);
			this->Button3->Name = L"Button3";
			this->Button3->Size = System::Drawing::Size(104, 24);
			this->Button3->TabIndex = 1;
			this->Button3->Text = L"Reset";
			this->Button3->Click += gcnew System::EventHandler(this, &Form1::Button3_Click);
			// 
			// TextBox2
			// 
			this->TextBox2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(0)));
			this->TextBox2->Location = System::Drawing::Point(6, 19);
			this->TextBox2->Name = L"TextBox2";
			this->TextBox2->Size = System::Drawing::Size(104, 20);
			this->TextBox2->TabIndex = 0;
			this->TextBox2->Text = L"0";
			// 
			// CheckBox3
			// 
			this->CheckBox3->Appearance = System::Windows::Forms::Appearance::Button;
			this->CheckBox3->Location = System::Drawing::Point(12, 284);
			this->CheckBox3->Name = L"CheckBox3";
			this->CheckBox3->Size = System::Drawing::Size(108, 24);
			this->CheckBox3->TabIndex = 61;
			this->CheckBox3->Text = L"Output Test";
			this->CheckBox3->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			this->CheckBox3->CheckedChanged += gcnew System::EventHandler(this, &Form1::CheckBox3_CheckedChanged);
			// 
			// Label1
			// 
			this->Label1->Location = System::Drawing::Point(12, 85);
			this->Label1->Name = L"Label1";
			this->Label1->Size = System::Drawing::Size(104, 16);
			this->Label1->TabIndex = 59;
			this->Label1->Text = L"- - -";
			// 
			// CheckBox15
			// 
			this->CheckBox15->Location = System::Drawing::Point(198, 17);
			this->CheckBox15->Name = L"CheckBox15";
			this->CheckBox15->Size = System::Drawing::Size(26, 15);
			this->CheckBox15->TabIndex = 11;
			this->CheckBox15->Text = L"7";
			this->CheckBox15->UseVisualStyleBackColor = true;
			this->CheckBox15->CheckedChanged += gcnew System::EventHandler(this, &Form1::CheckBox15_CheckedChanged);
			// 
			// CheckBox13
			// 
			this->CheckBox13->Location = System::Drawing::Point(134, 17);
			this->CheckBox13->Name = L"CheckBox13";
			this->CheckBox13->Size = System::Drawing::Size(26, 15);
			this->CheckBox13->TabIndex = 9;
			this->CheckBox13->Text = L"5";
			this->CheckBox13->UseVisualStyleBackColor = true;
			this->CheckBox13->CheckedChanged += gcnew System::EventHandler(this, &Form1::CheckBox13_CheckedChanged);
			// 
			// CheckBox11
			// 
			this->CheckBox11->Location = System::Drawing::Point(70, 17);
			this->CheckBox11->Name = L"CheckBox11";
			this->CheckBox11->Size = System::Drawing::Size(26, 15);
			this->CheckBox11->TabIndex = 7;
			this->CheckBox11->Text = L"3";
			this->CheckBox11->UseVisualStyleBackColor = true;
			this->CheckBox11->CheckedChanged += gcnew System::EventHandler(this, &Form1::CheckBox11_CheckedChanged);
			// 
			// Label9
			// 
			this->Label9->AutoSize = true;
			this->Label9->Location = System::Drawing::Point(10, 272);
			this->Label9->Name = L"Label9";
			this->Label9->Size = System::Drawing::Size(22, 13);
			this->Label9->TabIndex = 44;
			this->Label9->Text = L"- - -";
			// 
			// Button8
			// 
			this->Button8->Location = System::Drawing::Point(10, 160);
			this->Button8->Name = L"Button8";
			this->Button8->Size = System::Drawing::Size(97, 24);
			this->Button8->TabIndex = 42;
			this->Button8->Text = L"Search Devices";
			this->Button8->UseVisualStyleBackColor = true;
			this->Button8->Click += gcnew System::EventHandler(this, &Form1::Button8_Click);
			// 
			// GroupBox10
			// 
			this->GroupBox10->Controls->Add(this->Label9);
			this->GroupBox10->Controls->Add(this->Button9);
			this->GroupBox10->Controls->Add(this->Button8);
			this->GroupBox10->Controls->Add(this->Label8);
			this->GroupBox10->Controls->Add(this->RadioButton12);
			this->GroupBox10->Controls->Add(this->RadioButton11);
			this->GroupBox10->Controls->Add(this->RadioButton10);
			this->GroupBox10->Controls->Add(this->RadioButton9);
			this->GroupBox10->Location = System::Drawing::Point(646, 8);
			this->GroupBox10->Name = L"GroupBox10";
			this->GroupBox10->Size = System::Drawing::Size(120, 300);
			this->GroupBox10->TabIndex = 71;
			this->GroupBox10->TabStop = false;
			this->GroupBox10->Text = L"Multicard Commands";
			// 
			// Button9
			// 
			this->Button9->Location = System::Drawing::Point(10, 245);
			this->Button9->Name = L"Button9";
			this->Button9->Size = System::Drawing::Size(97, 24);
			this->Button9->TabIndex = 43;
			this->Button9->Text = L"DLL Version";
			this->Button9->UseVisualStyleBackColor = true;
			this->Button9->Click += gcnew System::EventHandler(this, &Form1::Button9_Click);
			// 
			// Label8
			// 
			this->Label8->AutoSize = true;
			this->Label8->Location = System::Drawing::Point(10, 31);
			this->Label8->Name = L"Label8";
			this->Label8->Size = System::Drawing::Size(97, 13);
			this->Label8->TabIndex = 41;
			this->Label8->Text = L"Set Current Device";
			// 
			// RadioButton12
			// 
			this->RadioButton12->AutoSize = true;
			this->RadioButton12->Enabled = false;
			this->RadioButton12->Location = System::Drawing::Point(24, 120);
			this->RadioButton12->Name = L"RadioButton12";
			this->RadioButton12->Size = System::Drawing::Size(68, 17);
			this->RadioButton12->TabIndex = 40;
			this->RadioButton12->TabStop = true;
			this->RadioButton12->Text = L"Device 3";
			this->RadioButton12->UseVisualStyleBackColor = true;
			this->RadioButton12->CheckedChanged += gcnew System::EventHandler(this, &Form1::RadioButton12_CheckedChanged);
			// 
			// RadioButton11
			// 
			this->RadioButton11->AutoSize = true;
			this->RadioButton11->Enabled = false;
			this->RadioButton11->Location = System::Drawing::Point(24, 97);
			this->RadioButton11->Name = L"RadioButton11";
			this->RadioButton11->Size = System::Drawing::Size(68, 17);
			this->RadioButton11->TabIndex = 39;
			this->RadioButton11->TabStop = true;
			this->RadioButton11->Text = L"Device 2";
			this->RadioButton11->UseVisualStyleBackColor = true;
			this->RadioButton11->CheckedChanged += gcnew System::EventHandler(this, &Form1::RadioButton11_CheckedChanged);
			// 
			// RadioButton10
			// 
			this->RadioButton10->AutoSize = true;
			this->RadioButton10->Enabled = false;
			this->RadioButton10->Location = System::Drawing::Point(24, 74);
			this->RadioButton10->Name = L"RadioButton10";
			this->RadioButton10->Size = System::Drawing::Size(68, 17);
			this->RadioButton10->TabIndex = 38;
			this->RadioButton10->TabStop = true;
			this->RadioButton10->Text = L"Device 1";
			this->RadioButton10->UseVisualStyleBackColor = true;
			this->RadioButton10->CheckedChanged += gcnew System::EventHandler(this, &Form1::RadioButton10_CheckedChanged);
			// 
			// RadioButton9
			// 
			this->RadioButton9->AutoSize = true;
			this->RadioButton9->Enabled = false;
			this->RadioButton9->Location = System::Drawing::Point(24, 51);
			this->RadioButton9->Name = L"RadioButton9";
			this->RadioButton9->Size = System::Drawing::Size(68, 17);
			this->RadioButton9->TabIndex = 37;
			this->RadioButton9->TabStop = true;
			this->RadioButton9->Text = L"Device 0";
			this->RadioButton9->UseVisualStyleBackColor = true;
			this->RadioButton9->CheckedChanged += gcnew System::EventHandler(this, &Form1::RadioButton9_CheckedChanged);
			// 
			// GroupBox3
			// 
			this->GroupBox3->Controls->Add(this->CheckBox2);
			this->GroupBox3->Controls->Add(this->CheckBox1);
			this->GroupBox3->Location = System::Drawing::Point(12, 8);
			this->GroupBox3->Name = L"GroupBox3";
			this->GroupBox3->Size = System::Drawing::Size(108, 44);
			this->GroupBox3->TabIndex = 57;
			this->GroupBox3->TabStop = false;
			this->GroupBox3->Text = L"Card Address";
			// 
			// Timer1
			// 
			this->Timer1->Interval = 50;
			this->Timer1->Tick += gcnew System::EventHandler(this, &Form1::Timer1_Tick);
			// 
			// CheckBox9
			// 
			this->CheckBox9->Location = System::Drawing::Point(6, 17);
			this->CheckBox9->Name = L"CheckBox9";
			this->CheckBox9->Size = System::Drawing::Size(26, 15);
			this->CheckBox9->TabIndex = 5;
			this->CheckBox9->Text = L"1";
			this->CheckBox9->UseVisualStyleBackColor = true;
			this->CheckBox9->CheckedChanged += gcnew System::EventHandler(this, &Form1::CheckBox9_CheckedChanged);
			// 
			// GroupBox2
			// 
			this->GroupBox2->Controls->Add(this->CheckBox16);
			this->GroupBox2->Controls->Add(this->CheckBox15);
			this->GroupBox2->Controls->Add(this->CheckBox14);
			this->GroupBox2->Controls->Add(this->CheckBox13);
			this->GroupBox2->Controls->Add(this->CheckBox12);
			this->GroupBox2->Controls->Add(this->CheckBox11);
			this->GroupBox2->Controls->Add(this->CheckBox10);
			this->GroupBox2->Controls->Add(this->CheckBox9);
			this->GroupBox2->Location = System::Drawing::Point(368, 51);
			this->GroupBox2->Name = L"GroupBox2";
			this->GroupBox2->Size = System::Drawing::Size(260, 40);
			this->GroupBox2->TabIndex = 56;
			this->GroupBox2->TabStop = false;
			this->GroupBox2->Text = L"Outputs";
			// 
			// CheckBox10
			// 
			this->CheckBox10->Location = System::Drawing::Point(38, 17);
			this->CheckBox10->Name = L"CheckBox10";
			this->CheckBox10->Size = System::Drawing::Size(26, 15);
			this->CheckBox10->TabIndex = 6;
			this->CheckBox10->Text = L"2";
			this->CheckBox10->UseVisualStyleBackColor = true;
			this->CheckBox10->CheckedChanged += gcnew System::EventHandler(this, &Form1::CheckBox10_CheckedChanged);
			// 
			// GroupBox4
			// 
			this->GroupBox4->Controls->Add(this->RadioButton4);
			this->GroupBox4->Controls->Add(this->RadioButton3);
			this->GroupBox4->Controls->Add(this->RadioButton2);
			this->GroupBox4->Controls->Add(this->RadioButton1);
			this->GroupBox4->Controls->Add(this->Label2);
			this->GroupBox4->Controls->Add(this->Button2);
			this->GroupBox4->Controls->Add(this->TextBox1);
			this->GroupBox4->Location = System::Drawing::Point(368, 124);
			this->GroupBox4->Name = L"GroupBox4";
			this->GroupBox4->Size = System::Drawing::Size(117, 184);
			this->GroupBox4->TabIndex = 60;
			this->GroupBox4->TabStop = false;
			this->GroupBox4->Text = L"Counter1";
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(772, 311);
			this->Controls->Add(this->GroupBox7);
			this->Controls->Add(this->GroupBox6);
			this->Controls->Add(this->Button7);
			this->Controls->Add(this->Button5);
			this->Controls->Add(this->GroupBox9);
			this->Controls->Add(this->GroupBox8);
			this->Controls->Add(this->Button6);
			this->Controls->Add(this->GroupBox1);
			this->Controls->Add(this->Button4);
			this->Controls->Add(this->Button1);
			this->Controls->Add(this->GroupBox5);
			this->Controls->Add(this->CheckBox3);
			this->Controls->Add(this->Label1);
			this->Controls->Add(this->GroupBox10);
			this->Controls->Add(this->GroupBox3);
			this->Controls->Add(this->GroupBox2);
			this->Controls->Add(this->GroupBox4);
			this->Name = L"Form1";
			this->Text = L"Form1";
			this->FormClosed += gcnew System::Windows::Forms::FormClosedEventHandler(this, &Form1::Form1_FormClosed);
			this->GroupBox7->ResumeLayout(false);
			this->GroupBox6->ResumeLayout(false);
			this->GroupBox9->ResumeLayout(false);
			this->GroupBox8->ResumeLayout(false);
			this->GroupBox1->ResumeLayout(false);
			this->GroupBox5->ResumeLayout(false);
			this->GroupBox5->PerformLayout();
			this->GroupBox10->ResumeLayout(false);
			this->GroupBox10->PerformLayout();
			this->GroupBox3->ResumeLayout(false);
			this->GroupBox2->ResumeLayout(false);
			this->GroupBox4->ResumeLayout(false);
			this->GroupBox4->PerformLayout();
			this->ResumeLayout(false);

		}
#pragma endregion
		static int n = 0;

		[DllImport("k8055d.dll", CharSet=CharSet::Ansi)]
        static int OpenDevice(int CardAddress);

        [DllImport("k8055d.dll", CharSet=CharSet::Ansi)]
        static void CloseDevice();

        [DllImport("k8055d.dll", CharSet=CharSet::Ansi)]
        static int ReadAnalogChannel(int Channel);

        [DllImport("k8055d.dll", CharSet=CharSet::Ansi)]
        static void ReadAllAnalog(int *Data1, int *Data2);

        [DllImport("k8055d.dll", CharSet=CharSet::Ansi)]
        static void OutputAnalogChannel(int Channel, int Data);

        [DllImport("k8055d.dll", CharSet=CharSet::Ansi)]
        static void OutputAllAnalog(int Data1, int Data2);

        [DllImport("k8055d.dll", CharSet=CharSet::Ansi)]
        static void ClearAnalogChannel(int Channel);

        [DllImport("k8055d.dll", CharSet=CharSet::Ansi)]
        static void SetAllAnalog();

        [DllImport("k8055d.dll", CharSet=CharSet::Ansi)]
        static void ClearAllAnalog();

        [DllImport("k8055d.dll", CharSet=CharSet::Ansi)]
        static void SetAnalogChannel(int Channel);

        [DllImport("k8055d.dll", CharSet=CharSet::Ansi)]
        static void WriteAllDigital(int Data);

        [DllImport("k8055d.dll", CharSet=CharSet::Ansi)]
        static void ClearDigitalChannel(int Channel);

        [DllImport("k8055d.dll", CharSet=CharSet::Ansi)]
        static void ClearAllDigital();

        [DllImport("k8055d.dll", CharSet=CharSet::Ansi)]
        static void SetDigitalChannel(int Channel);

        [DllImport("k8055d.dll", CharSet=CharSet::Ansi)]
        static void SetAllDigital();

        [DllImport("k8055d.dll", CharSet=CharSet::Ansi)]
        static bool ReadDigitalChannel(int Channel);

        [DllImport("k8055d.dll", CharSet=CharSet::Ansi)]
        static int ReadAllDigital();

        [DllImport("k8055d.dll", CharSet=CharSet::Ansi)]
        static int ReadCounter(int CounterNr);

        [DllImport("k8055d.dll", CharSet=CharSet::Ansi)]
        static void ResetCounter(int CounterNr);

        [DllImport("k8055d.dll", CharSet=CharSet::Ansi)]
        static void SetCounterDebounceTime(int CounterNr, int DebounceTime);

        [DllImport("k8055d.dll", CharSet=CharSet::Ansi)]
        static int Version();

        [DllImport("k8055d.dll", CharSet=CharSet::Ansi)]
        static int SearchDevices();

        [DllImport("k8055d.dll", CharSet=CharSet::Ansi)]
        static int SetCurrentDevice(int lngCardAddress);

	private: System::Void Button1_Click(System::Object^  sender, System::EventArgs^  e) 
			 {
				int CardAddr = 3 - (int(CheckBox1->Checked) + int(CheckBox2->Checked) * 2);
				int h = OpenDevice(CardAddr);
				switch (h) 
				{
					case  0:
					case  1:
					case  2:
					case  3: 
						Label1->Text = "Card " + h.ToString() + " connected";
						Timer1->Enabled = true;
					break;
					case  -1 :
						Label1->Text = "Card " + CardAddr.ToString() + " not found";
					break;
				}
			 }
private: System::Void Form1_FormClosed(System::Object^  sender, System::Windows::Forms::FormClosedEventArgs^  e) 
		 {
			 CloseDevice();
		 }
private: System::Void Timer1_Tick(System::Object^  sender, System::EventArgs^  e) 
		 {
			  Timer1->Enabled = false;
			  int Data1;
			  int Data2;
			  int i;
			  ReadAllAnalog(&Data1, &Data2);
			  VScrollBar3->Value = 255 - Data1;
			  VScrollBar4->Value = 255 - Data2;
			  Label6->Text = Data1.ToString();
			  Label7->Text = Data2.ToString();
			  TextBox1->Text = ReadCounter(1).ToString();
			  TextBox2->Text = ReadCounter(2).ToString();
			  i = ReadAllDigital();
			  CheckBox4->Checked = (i & 1)>0;
			  CheckBox5->Checked = (i & 2)>0;
			  CheckBox6->Checked = (i & 4)>0;
			  CheckBox7->Checked = (i & 8)>0;
			  CheckBox8->Checked = (i & 16)>0;
			  Timer1->Enabled = true;

		 }
private: System::Void Timer2_Tick(System::Object^  sender, System::EventArgs^  e) 
		 {
			ClearDigitalChannel(n);
            n++;
            if (n == 9)
                n = 1;
            SetDigitalChannel(n);
		 }
private: System::Void Button4_Click(System::Object^  sender, System::EventArgs^  e) 
		 {
			SetAllDigital();
            CheckBox9->Checked = true;
            CheckBox10->Checked = true;
            CheckBox11->Checked = true;
            CheckBox12->Checked = true;
            CheckBox13->Checked = true;
            CheckBox14->Checked = true;
            CheckBox15->Checked = true;
            CheckBox16->Checked = true;
		 }
private: System::Void Button5_Click(System::Object^  sender, System::EventArgs^  e) 
		 {
			ClearAllDigital();
            CheckBox9->Checked = false;
            CheckBox10->Checked = false;
            CheckBox11->Checked = false;
            CheckBox12->Checked = false;
            CheckBox13->Checked = false;
            CheckBox14->Checked = false;
            CheckBox15->Checked = false;
            CheckBox16->Checked = false;
		 }
private: System::Void Button7_Click(System::Object^  sender, System::EventArgs^  e) 
		 {
			SetAllAnalog();
            VScrollBar1->Value = 0;
            VScrollBar2->Value = 0;
		 }
private: System::Void Button6_Click(System::Object^  sender, System::EventArgs^  e) 
		 {
			ClearAllAnalog();
            VScrollBar1->Value = 255;
            VScrollBar2->Value = 255;
		 }
private: System::Void CheckBox3_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		 {
			if (CheckBox3->Checked)
            {
                Timer2->Enabled = true;
            }
            else
            {
                Timer2->Enabled = false;
                ClearAllDigital();
                CheckBox9->Checked = false;
                CheckBox10->Checked = false;
                CheckBox11->Checked = false;
                CheckBox12->Checked = false;
                CheckBox13->Checked = false;
                CheckBox14->Checked = false;
                CheckBox15->Checked = false;
                CheckBox16->Checked = false;
            }
		 }
private: System::Void VScrollBar1_Scroll(System::Object^  sender, System::Windows::Forms::ScrollEventArgs^  e) 
		 {
			OutputAnalogChannel(1, 255 - VScrollBar1->Value);
            Label4->Text = (255 - VScrollBar1->Value).ToString();
		 }
private: System::Void VScrollBar2_Scroll(System::Object^  sender, System::Windows::Forms::ScrollEventArgs^  e) 
		 {
			OutputAnalogChannel(2, 255 - VScrollBar2->Value);
            Label5->Text = (255 - VScrollBar2->Value).ToString();
		 }
private: System::Void Button2_Click(System::Object^  sender, System::EventArgs^  e) 
		 {
			ResetCounter(1);
		 }
private: System::Void Button3_Click(System::Object^  sender, System::EventArgs^  e) 
		 {
			ResetCounter(2);
		 }
private: System::Void RadioButton1_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		 {
			SetCounterDebounceTime(1, 0);
		 }
private: System::Void RadioButton2_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		 {
			SetCounterDebounceTime(1, 2);
		 }
private: System::Void RadioButton3_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		 {
			SetCounterDebounceTime(1, 10);
		 }
private: System::Void RadioButton4_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		 {
			SetCounterDebounceTime(1, 1000);
		 }
private: System::Void RadioButton5_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		 {
			SetCounterDebounceTime(2, 0);
		 }
private: System::Void RadioButton6_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		 {
			SetCounterDebounceTime(2, 2);
		 }
private: System::Void RadioButton7_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		 {
			SetCounterDebounceTime(21, 10);
		 }
private: System::Void RadioButton8_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		 {
			SetCounterDebounceTime(2, 1000);
		 }
private: System::Void CheckBox9_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		 {
			CheckBox9->Checked ? SetDigitalChannel(1): ClearDigitalChannel(1);
		 }
private: System::Void CheckBox10_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		 {
			CheckBox10->Checked ? SetDigitalChannel(2): ClearDigitalChannel(2);
		 }
private: System::Void CheckBox11_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		 {
			CheckBox11->Checked ? SetDigitalChannel(3): ClearDigitalChannel(3);
		 }
private: System::Void CheckBox12_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		 {
			CheckBox12->Checked ? SetDigitalChannel(4): ClearDigitalChannel(4);
		 }
private: System::Void CheckBox13_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		 {
			CheckBox13->Checked ? SetDigitalChannel(5): ClearDigitalChannel(5);
		 }
private: System::Void CheckBox14_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		 {
			CheckBox14->Checked ? SetDigitalChannel(6): ClearDigitalChannel(6);
		 }
private: System::Void CheckBox15_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		 {
			CheckBox15->Checked ? SetDigitalChannel(7): ClearDigitalChannel(7);
		 }
private: System::Void CheckBox16_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		 {
			CheckBox16->Checked ? SetDigitalChannel(8): ClearDigitalChannel(8);
		 }
private: System::Void Button8_Click(System::Object^  sender, System::EventArgs^  e) 
		 {
			int k;
			bool CardFound = false;
			Timer1->Enabled = false;
			RadioButton9->Enabled = false;
			RadioButton9->Checked = false;
			RadioButton10->Enabled = false;
			RadioButton10->Checked = false;
			RadioButton11->Enabled = false;
			RadioButton11->Checked = false;
			RadioButton12->Enabled = false;
			RadioButton12->Checked = false;
			k = SearchDevices();					
			if (k) 
				Timer1->Enabled = true;
			if (k & 1)
			{
				RadioButton9->Enabled = true;
				if (!CardFound)
				{
					RadioButton9->Checked = true;
					SetCurrentDevice (0);
					CardFound = true;
				}
			}
			if (k & 2)
			{
				RadioButton10->Enabled = true;
				if (!CardFound)
				{
					RadioButton10->Checked = true;
					SetCurrentDevice (1);
					CardFound = true;
				}
			}
			if (k & 4)
			{
				RadioButton11->Enabled = true;
				if (!CardFound)
				{
					RadioButton11->Checked = true;
					SetCurrentDevice (2);
					CardFound = true;
				}
			}
			if (k & 8)
			{
				RadioButton12->Enabled = true;
				if (!CardFound)
				{
					RadioButton12->Checked = true;
					SetCurrentDevice (3);
				}
			} 
		 }
private: System::Void RadioButton9_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		 {
			 SetCurrentDevice(0);
		 }
private: System::Void RadioButton10_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		 {
			 SetCurrentDevice(1);
		 }
private: System::Void RadioButton11_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		 {
			 SetCurrentDevice(2);
		 }
private: System::Void RadioButton12_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		 {
			 SetCurrentDevice(3);
		 }
private: System::Void Button9_Click(System::Object^  sender, System::EventArgs^  e) 
		 {
			int ver = Version();
			Label9->Text = (ver >> 24).ToString()+"."+((ver >> 16) & 0xFF).ToString()+"."
				+((ver >> 8) & 0xFF).ToString()+"."+(ver & 0xFF).ToString();
		 }
};
}

