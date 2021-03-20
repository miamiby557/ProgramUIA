using Inspect.My;
using Inspect.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Forms;
using System.Xml;

namespace Inspect
{
	[DesignerGenerated]
	public class Form1 : Form
	{
		public struct RECT
		{
			public int Left;

			public int Top;

			public int Right;

			public int Bottom;
		}

		public struct POINTAPI
		{
			public int x;

			public int y;
		}

		public const int R2_NOTXORPEN = 10;

		private Dictionary<TreeNode, AutomationElement> dic;

		private TreeNode RootNode;

		private AutomationElement RootElement;

		private TreeNode CurrentNode;

		private AutomationElement CurrentElement;

		private TreeWalker TW;

		private PropertyCondition Custom;

		private ColumnHeader Column;

		private ListViewItem Row;

		private System.Windows.Point Pt;

		private Rect Rec;

		private Form1.POINTAPI P;

		private Form1.RECT R;

		private int hDC;

		private int Pen;

		private int PreviousPen;

		private XmlDocument Doc;

		private XmlElement Root_XML;

		private TreeNode Root_Tree;

		private AutomationFocusChangedEventHandler FocusChangedEvent;

		private IContainer components;

		[DebuggerBrowsable(DebuggerBrowsableState.Never), AccessedThroughProperty("TreeView1"), CompilerGenerated]
		private TreeView _TreeView1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never), AccessedThroughProperty("Splitter1"), CompilerGenerated]
		private Splitter _Splitter1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never), AccessedThroughProperty("ListView1"), CompilerGenerated]
		private ListView _ListView1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never), AccessedThroughProperty("Button1"), CompilerGenerated]
		private Button _Button1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never), AccessedThroughProperty("Timer1"), CompilerGenerated]
		private System.Windows.Forms.Timer _Timer1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never), AccessedThroughProperty("ContextMenuStrip1"), CompilerGenerated]
		private ContextMenuStrip _ContextMenuStrip1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never), AccessedThroughProperty("menuExportXML"), CompilerGenerated]
		private ToolStripMenuItem _menuExportXML;

		[DebuggerBrowsable(DebuggerBrowsableState.Never), AccessedThroughProperty("ContextMenuStrip2"), CompilerGenerated]
		private ContextMenuStrip _ContextMenuStrip2;

		[DebuggerBrowsable(DebuggerBrowsableState.Never), AccessedThroughProperty("menuCopyValue"), CompilerGenerated]
		private ToolStripMenuItem _menuCopyValue;

		[DebuggerBrowsable(DebuggerBrowsableState.Never), AccessedThroughProperty("ToolTip1"), CompilerGenerated]
		private ToolTip _ToolTip1;

		internal virtual TreeView TreeView1
		{
			[CompilerGenerated]
			get
			{
				return this._TreeView1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				TreeViewEventHandler value2 = new TreeViewEventHandler(this.TreeView1_AfterSelect);
				TreeView treeView = this._TreeView1;
				if (treeView != null)
				{
					treeView.AfterSelect -= value2;
				}
				this._TreeView1 = value;
				treeView = this._TreeView1;
				if (treeView != null)
				{
					treeView.AfterSelect += value2;
				}
			}
		}

		internal virtual Splitter Splitter1
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual ListView ListView1
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Button Button1
		{
			[CompilerGenerated]
			get
			{
				return this._Button1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button1_Click);
				Button button = this._Button1;
				if (button != null)
				{
					button.Click -= value2;
				}
				this._Button1 = value;
				button = this._Button1;
				if (button != null)
				{
					button.Click += value2;
				}
			}
		}

		internal virtual System.Windows.Forms.Timer Timer1
		{
			[CompilerGenerated]
			get
			{
				return this._Timer1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Timer1_Tick);
				System.Windows.Forms.Timer timer = this._Timer1;
				if (timer != null)
				{
					timer.Tick -= value2;
				}
				this._Timer1 = value;
				timer = this._Timer1;
				if (timer != null)
				{
					timer.Tick += value2;
				}
			}
		}

		internal virtual ContextMenuStrip ContextMenuStrip1
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual ContextMenuStrip ContextMenuStrip2
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual ToolStripMenuItem menuCopyValue
		{
			[CompilerGenerated]
			get
			{
				return this._menuCopyValue;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.menuCopyValue_Click);
				ToolStripMenuItem menuCopyValue = this._menuCopyValue;
				if (menuCopyValue != null)
				{
					menuCopyValue.Click -= value2;
				}
				this._menuCopyValue = value;
				menuCopyValue = this._menuCopyValue;
				if (menuCopyValue != null)
				{
					menuCopyValue.Click += value2;
				}
			}
		}

		internal virtual ToolTip ToolTip1
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		public Form1()
		{
			base.Load += new EventHandler(this.Form1_Load);
			this.InitializeComponent();
			this.ControlBox = false;
		}

		[DllImport("gdi32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int CreatePen(int nPenStyle, int nWidth, int crColor);

		[DllImport("gdi32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int SelectObject(int hdc, int hObject);

		[DllImport("gdi32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int SetROP2(int hdc, int nDrawMode);

		[DllImport("gdi32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int Rectangle(int hdc, int X1, int Y1, int X2, int Y2);

		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int GetDC(int hwnd);

		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int ReleaseDC(int hwnd, int hdc);

		[DllImport("gdi32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int DeleteObject(int hObject);

		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int ReleaseCapture();

		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int GetCursorPos(ref Form1.POINTAPI lpPoint);

		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern short GetAsyncKeyState(int vKey);

		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int RegisterHotKey(int hwnd, int id, int fsModifiers, int vk);

		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int UnregisterHotKey(int hwnd, int id);

		public void LoopElement(AutomationElement ParentElement, TreeNode ParentNode)
		{
			try
			{
				AutomationElementCollection automationElementCollection = ParentElement.FindAll(TreeScope.Children, Condition.TrueCondition);
				IEnumerator enumerator = null;
				try
				{
					enumerator = automationElementCollection.GetEnumerator();
					while (enumerator.MoveNext())
					{
						AutomationElement automationElement = (AutomationElement)enumerator.Current;
						TreeNodeCollection arg_59_0 = ParentNode.Nodes;
						AutomationElement.AutomationElementInformation current = automationElement.Current;
						string arg_54_0 = current.Name;
						string arg_54_1 = " ";
						current = automationElement.Current;
						TreeNode treeNode = arg_59_0.Add(arg_54_0 + arg_54_1 + current.LocalizedControlType.ToString());
						this.dic.Add(treeNode, automationElement);
						bool flag = automationElement.Equals(this.CurrentElement);
						if (flag)
						{
							this.CurrentNode = treeNode;
						}
						this.LoopElement(automationElement, treeNode);
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
			}
			catch (ElementNotAvailableException expr_BA)
			{
				ProjectData.SetProjectError(expr_BA);
				ProjectData.ClearProjectError();
			}
		}

		private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			this.CurrentElement = this.dic[e.Node];
			try
			{
				AutomationElement.AutomationElementInformation current = this.CurrentElement.Current;
				bool flag = !current.IsOffscreen;
				if (flag)
				{
					this.ShowProperty();
				}
			}
			catch (ElementNotAvailableException expr_3E)
			{
				ProjectData.SetProjectError(expr_3E);
				ElementNotAvailableException ex = expr_3E;
				this.ListView1.Items.Clear();
				MessageBox.Show(ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}

		private void ShowProperty()
		{
			this.ListView1.Items.Clear();
			try
			{
				AutomationElement.AutomationElementInformation current = this.CurrentElement.Current;
				this.AddItems("名称", "Name", current.Name);
				this.AddItems("本地类型", "LocalizedControlType", current.LocalizedControlType);
				this.AddItems("控件类型", "ControlType", current.ControlType.ProgrammaticName);
				this.AddItems("类名", "ClassName", current.ClassName);
				this.AddItems("句柄", "NativeWindowHandle", Conversions.ToString(current.NativeWindowHandle));
				this.AddItems("进程", "ProcessId", Conversions.ToString(current.ProcessId));
				this.AddItems("自动化", "AutomationId", current.AutomationId);
				this.Rec = current.BoundingRectangle;
				this.AddItems("矩形", "BoundingRectangle", string.Format("({0},{1}),({2},{3})", new object[]
				{
					this.Rec.Left,
					this.Rec.Top,
					this.Rec.Right,
					this.Rec.Bottom
				}));
				this.AddItems("快捷键", "AcceleratorKey", current.AcceleratorKey);
				this.AddItems("快速访问键", "AccessKey", current.AccessKey);
				this.AddItems("具有键盘焦点", "HasKeyboardFocus", Conversions.ToString(current.HasKeyboardFocus));
				this.AddItems("可接受键盘焦点", "IsKeyboardFocusable", Conversions.ToString(current.IsKeyboardFocusable));
				this.AddItems("可用", "IsEnabled", Conversions.ToString(current.IsEnabled));
				this.AddItems("消失", "IsOffscreen", Conversions.ToString(current.IsOffscreen));
				this.AddItems("是内容元素", "IsContentElement", Conversions.ToString(current.IsContentElement));
				this.AddItems("是控件元素", "IsControlElement", Conversions.ToString(current.IsControlElement));
				this.AddItems("是密码框", "IsPassword", Conversions.ToString(current.IsPassword));
				this.DrawRectangle();
			}
			catch (Exception expr_254)
			{
				ProjectData.SetProjectError(expr_254);
				ProjectData.ClearProjectError();
				return;
			}
			try
			{
				this.Pt = this.CurrentElement.GetClickablePoint();
				this.AddItems("中心坐标", "ClickablePoint", string.Format("({0},{1})", this.Pt.X, this.Pt.Y));
			}
			catch (Exception expr_2B6)
			{
				ProjectData.SetProjectError(expr_2B6);
				ProjectData.ClearProjectError();
			}
			AutomationPattern[] supportedPatterns = this.CurrentElement.GetSupportedPatterns();
			AutomationPattern[] array = supportedPatterns;
			checked
			{
				for (int i = 0; i < array.Length; i++)
				{
					AutomationPattern pattern = array[i];
					this.AddItems("可用模式", "GetSupportedPatterns", Automation.PatternName(pattern) + "Pattern");
				}
			}
		}

		private void AddItems(string Column0, string Column1, string Column2)
		{
			this.Row = this.ListView1.Items.Add(Column0);
			this.Row.SubItems.Add(Column1);
			this.Row.SubItems.Add(Column2);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			ListView listView = this.ListView1;
			listView.View = View.Details;
			listView.FullRowSelect = true;
			listView.MultiSelect = false;
			listView.GridLines = true;
			listView.Columns.Clear();
			listView.Items.Clear();

			this.Column = listView.Columns.Add("本地属性", 100);
			this.Column = listView.Columns.Add("程序属性", 200);
			this.Column = listView.Columns.Add("值", 200);
			this.TreeView1.LabelEdit = true;
			base.Icon = Resources.magnify;
			this.Button1.Image = Resources.eye.ToBitmap();
			this.Custom = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Custom);
			this.hDC = Form1.GetDC(0);
			this.Pen = Form1.CreatePen(0, 2, 255);
			this.PreviousPen = Form1.SelectObject(this.hDC, this.Pen);
            Form1.SetROP2(this.hDC, 10);
            this.ListView1.Items.Clear();
			this.TreeView1.Nodes.Clear();
			this.RootElement = null;
			this.CurrentElement = null;
			this.Button1.Enabled = false;
			this.Timer1.Start();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			this.ListView1.Items.Clear();
			this.TreeView1.Nodes.Clear();
			this.RootElement = null;
			this.CurrentElement = null;
			this.Button1.Enabled = false;
			this.Timer1.Start();
		}

		private void FocusChangedEvent_OnFocusChanged(object sender, AutomationFocusChangedEventArgs e)
		{
			bool flag = sender == null;
			if (!flag)
			{
				bool flag2 = e.EventId == AutomationElementIdentifiers.AutomationFocusChangedEvent;
				if (flag2)
				{
					this.CurrentElement = (AutomationElement)sender;
					this.DrawRectangle();
					this.ShowProperty();
				}
			}
		}

		private void DrawRectangle()
		{
			checked
			{
				try
				{
					AutomationElement.AutomationElementInformation current = this.CurrentElement.Current;
					this.Rec = current.BoundingRectangle;
					bool flag = Operators.CompareString(this.Rec.ToString(), "Empty", false) != 0;
					if (flag)
					{
						Form1.Rectangle(this.hDC, (int)Math.Round(this.Rec.Left), (int)Math.Round(this.Rec.Top), (int)Math.Round(this.Rec.Right), (int)Math.Round(this.Rec.Bottom));
						Thread.Sleep(100);
						Form1.Rectangle(this.hDC, (int)Math.Round(this.Rec.Left), (int)Math.Round(this.Rec.Top), (int)Math.Round(this.Rec.Right), (int)Math.Round(this.Rec.Bottom));
					}
				}
				catch (ElementNotAvailableException expr_ED)
				{
					// ProjectData.SetProjectError(expr_ED);
					ProjectData.ClearProjectError();
				}
			}
		}

		private void Timer1_Tick(object sender, EventArgs e)
		{
			Form1.GetCursorPos(ref this.P);
			this.Pt.X = (double)this.P.x;
			this.Pt.Y = (double)this.P.y;
			try
			{
				this.CurrentElement = AutomationElement.FromPoint(this.Pt);
				AutomationElement.AutomationElementInformation current = this.CurrentElement.Current;
				bool flag = current.ProcessId == Process.GetCurrentProcess().Id;
				if (flag)
				{
					return;
				}
			}
			catch (Exception expr_7A)
			{
				ProjectData.SetProjectError(expr_7A);
				ProjectData.ClearProjectError();
			}
			this.DrawRectangle();
			bool flag2 = ((int)Form1.GetAsyncKeyState(17) & 32768) != 0;
			if (flag2)
			{
				AutomationElement.AutomationElementInformation current = this.CurrentElement.Current;
				this.RootElement = this.CurrentElement;
				this.TW = TreeWalker.ControlViewWalker;

				// 上一个节点
				AutomationElement lastElement = this.TW.GetParent(this.RootElement);
				AutomationElement.AutomationElementInformation lastAutomationElementInformation = lastElement.Current;

				while (true)
				{
					bool flag3 = this.TW.GetParent(this.RootElement).Equals(AutomationElement.RootElement);
					if (flag3)
					{
						break;
					}
					this.RootElement = this.TW.GetParent(this.RootElement);
				}

				//  找到上一级
				/*this.TreeView1.Nodes.Clear();
				TreeNodeCollection treeNodeCollection = this.TreeView1.Nodes;
				current = this.RootElement.Current;
				this.RootNode = treeNodeCollection.Add(current.Name + " " + current.LocalizedControlType.ToString());
				this.dic = new Dictionary<TreeNode, AutomationElement>();
				this.dic.Add(this.RootNode, this.RootElement);
				this.LoopElement(this.RootElement, this.RootNode);
				*//*Console.WriteLine("parent:"+ this.dic(this.RootNode.LastNode));*/


				string pearentName = this.RootElement.Current.Name;
				string pearentClass = this.RootElement.Current.ClassName;
				/*string[] sourceArray = new string[]
                {
					"父名称:" + pearentName,
					"父类名:" + pearentClass,
					"名称:" + current.Name,
					"本地类型:" + current.LocalizedControlType,
					"控件类型:" + current.ControlType.ProgrammaticName,
					"类名:" + current.ClassName,
					"句柄:" + Conversions.ToString(current.NativeWindowHandle),
					"进程:" + Conversions.ToString(current.ProcessId)
				};
                MessageBox.Show(Strings.Join(sourceArray, "\r\n"), "句柄信息");*/
				Dictionary<string, object> rootParent = new Dictionary<string, object>();
				rootParent.Add("currentName", this.RootElement.Current.Name);
				rootParent.Add("currentClassName", this.RootElement.Current.ClassName);
				rootParent.Add("currentNativeWindowHandle", Conversions.ToString(this.RootElement.Current.NativeWindowHandle));
				rootParent.Add("currentProcessId", Conversions.ToString(this.RootElement.Current.ProcessId));
				rootParent.Add("currentControlTypeProgrammaticName", this.RootElement.Current.ControlType.ProgrammaticName);
				rootParent.Add("AutomationId", this.RootElement.Current.AutomationId);
				rootParent.Add("index", "1");
				Dictionary<string, object> lastParent = new Dictionary<string, object>();
				lastParent.Add("currentName", lastAutomationElementInformation.Name);
				lastParent.Add("currentClassName", lastAutomationElementInformation.ClassName);
				lastParent.Add("currentNativeWindowHandle", Conversions.ToString(lastAutomationElementInformation.NativeWindowHandle));
				lastParent.Add("currentProcessId", Conversions.ToString(lastAutomationElementInformation.ProcessId));
				lastParent.Add("currentControlTypeProgrammaticName", lastAutomationElementInformation.ControlType.ProgrammaticName);
				lastParent.Add("AutomationId", lastAutomationElementInformation.AutomationId);
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary.Add("rootParent", rootParent);
				dictionary.Add("lastParent", lastParent);
				dictionary.Add("currentName", current.Name);
				dictionary.Add("text", current.Name);
				dictionary.Add("currentClassName", current.ClassName);
				dictionary.Add("currentNativeWindowHandle", Conversions.ToString(current.NativeWindowHandle));
				dictionary.Add("currentProcessId", Conversions.ToString(current.ProcessId));
				dictionary.Add("currentControlTypeProgrammaticName", current.ControlType.ProgrammaticName);
				dictionary.Add("AutomationId", current.AutomationId);
				dictionary.Add("x", this.Rec.Left);
				dictionary.Add("y", this.Rec.Top);
				dictionary.Add("w", this.Rec.Right);
				dictionary.Add("h", this.Rec.Bottom);
				/*dictionary.Add("AccessKey", current.AccessKey);*/

				// 截图 转字符串
				this.Rec = current.BoundingRectangle;
				Console.WriteLine("this.Rec.Left:"+ this.Rec.Left.ToString()+ ",this.Rec.Top:"+ this.Rec.Top.ToString()+ ",this.Rec.Right:"+ this.Rec.Right.ToString()+ ",this.Rec.Bottom:"+ this.Rec.Bottom.ToString());
				Form1.Rectangle(this.hDC, (int)Math.Round(this.Rec.Left), (int)Math.Round(this.Rec.Top), (int)Math.Round(this.Rec.Right), (int)Math.Round(this.Rec.Bottom));
				// Bitmap image = this.SaveImage((int)Math.Round(this.Rec.Left-50), (int)Math.Round(this.Rec.Top-50), (int)Math.Round(this.Rec.Right+50), (int)Math.Round(this.Rec.Bottom+50));
				String imagePath = this.SaveImage((int)Math.Round(this.Rec.Left), (int)Math.Round(this.Rec.Top), (int)Math.Round(this.Rec.Right- this.Rec.Left), (int)Math.Round(this.Rec.Bottom- this.Rec.Top));
				// string base64FromImage = ImageUtil.GetBase64FromImage(image);
				dictionary.Add("screenShot", imagePath);
				PostData(dictionary);
			}
			else
			{
				this.ShowProperty();
			}
		}

		// 保存截图
		/*private Bitmap SaveImage(int x, int y, int width, int height)
		{
			Bitmap bitmap = new Bitmap(width, height);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.CopyFromScreen(x, y, 0, 0, new System.Drawing.Size(width, height));
			string imagePath = Directory.GetCurrentDirectory() + "\\img.png";
			Console.WriteLine("imagePath:"+ imagePath);
			bitmap.Save("img.png", ImageFormat.Png);
			return bitmap;
		}*/
		private String SaveImage(int x, int y, int width, int height)
		{
			Bitmap bitmap = new Bitmap(width, height);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.CopyFromScreen(x, y, 0, 0, new System.Drawing.Size(width, height));
			String imagePath = Directory.GetCurrentDirectory() + "\\img.png";
			Console.WriteLine("imagePath:" + imagePath);
			bitmap.Save(imagePath, ImageFormat.Png);
			return imagePath;
		}

		private Object o = new Object();

		private void PostData(Dictionary<string, object> dictionary)
        {
            lock (o)
            {
				try
				{
					/*string url = "http://localhost:63361/postData";
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    req.Method = "POST";
                    req.Timeout = 4000;//设置请求超时时间，单位为毫秒
                    req.ContentType = "application/json";
                    byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dictionary));
                    req.ContentLength = data.Length;
                    using (Stream reqStream = req.GetRequestStream())
                    {
                        reqStream.Write(data, 0, data.Length);
                        reqStream.Close();
                        // 关闭
                        this.Close();
                        Application.Exit();
                    }*/
					Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
					//连接服务器
					socket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10083));
					dictionary.Add("dataType","PROGRAM_UIA");
					socket.Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dictionary)));
					socket.Close();
					// 关闭
					this.Close();
					Application.Exit();
				}
				catch (Exception)
				{
					// 关闭
					this.Close();
					Application.Exit();
				}
			}
		}

		private void menuCopyValue_Click(object sender, EventArgs e)
		{
			bool flag = this.ListView1.SelectedItems.Count == 1;
			if (flag)
			{
				MyProject.Computer.Clipboard.SetText(this.ListView1.SelectedItems[0].SubItems[2].Text);
			}
		}

		protected override void WndProc(ref Message m)
		{
			bool flag = m.Msg == 786;
			if (flag)
			{
				this.ListView1.Items.Clear();
				this.TreeView1.Nodes.Clear();
				this.RootElement = null;
				this.CurrentElement = null;
				this.Button1.Enabled = false;
				this.Timer1.Stop();
				this.dic = new Dictionary<TreeNode, AutomationElement>();
				this.RootElement = AutomationElement.RootElement;
				TreeNodeCollection arg_B5_0 = this.TreeView1.Nodes;
				AutomationElement.AutomationElementInformation current = this.RootElement.Current;
				string arg_B0_0 = current.Name;
				string arg_B0_1 = " ";
				current = this.RootElement.Current;
				this.RootNode = arg_B5_0.Add(arg_B0_0 + arg_B0_1 + current.LocalizedControlType.ToString());
				this.dic.Add(this.RootNode, this.RootElement);
				this.LoopElement(this.RootElement, this.RootNode);
				this.TreeView1.ExpandAll();
				this.TreeView1.Focus();
				this.TreeView1.SelectedNode = this.RootNode;
				this.Button1.Enabled = true;
			}
			base.WndProc(ref m);
		}

		[DebuggerNonUserCode]
		protected override void Dispose(bool disposing)
		{
			try
			{
				bool flag = disposing && this.components != null;
				if (flag)
				{
					this.components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		private void hook_KeyDown(object sender, KeyEventArgs e)
		{
			//  这里写具体实现
			Console.WriteLine("按下按键" + e.KeyValue);
			if (e.KeyValue == 27)
			{
				k_hook.Stop();//卸载键盘钩子
				this.Close();
				Application.Exit();
			}
		}

		private KeyEventHandler myKeyEventHandeler = null;//按键钩子
		private KeyboardHook k_hook = new KeyboardHook();

		[DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.components = new Container();
			this.TreeView1 = new TreeView();
			this.ContextMenuStrip1 = new ContextMenuStrip(this.components);
			this.Splitter1 = new Splitter();
			this.ListView1 = new ListView();
			this.ContextMenuStrip2 = new ContextMenuStrip(this.components);
			this.menuCopyValue = new ToolStripMenuItem();
			this.Button1 = new Button();
			this.Timer1 = new System.Windows.Forms.Timer(this.components);
			this.ContextMenuStrip1.SuspendLayout();
			this.ContextMenuStrip2.SuspendLayout();
			base.SuspendLayout();
			
			this.Timer1.Interval = 1000;
			base.AutoScaleDimensions = new SizeF(8f, 16f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(200, 30);
			this.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
			base.Margin = new Padding(4);
			base.Name = "CINDATA AUTOMATION";
			base.StartPosition = FormStartPosition.Manual;
			Rectangle rect = Screen.GetWorkingArea(this);
			System.Drawing.Point p = new System.Drawing.Point(rect.Width-250, rect.Height-40);
			this.Location = p;
			this.Text = "应用程序拾取程序";
			base.TopMost = true;
			this.ContextMenuStrip1.ResumeLayout(false);
			this.ContextMenuStrip2.ResumeLayout(false);
			base.ResumeLayout(false);

			myKeyEventHandeler = new KeyEventHandler(hook_KeyDown);
			k_hook.KeyDownEvent += myKeyEventHandeler;//钩住键按下
			k_hook.Start();//安装键盘钩子
		}
	}
}
