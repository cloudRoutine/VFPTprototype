namespace VFPTprototype
open System
open System.Collections.Generic                              
open System.Threading
open System.Windows.Threading
open System.Collections.Generic                   
open System.Collections.ObjectModel               
open System.ComponentModel.Composition           
open System.Runtime.InteropServices               
open EnvDTE
open Microsoft.VisualStudio
open Microsoft.VisualStudio.Language.Intellisense 
open Microsoft.VisualStudio.Text                  
open Microsoft.VisualStudio.Text.Editor           
open Microsoft.VisualStudio.TextManager.Interop   
open Microsoft.VisualStudio.Utilities             
open Microsoft.VisualStudio.Editor                
open Microsoft.VisualStudio.Text.Operations       
open Microsoft.VisualStudio                       
open Microsoft.VisualStudio.ComponentModelHost
open Microsoft.VisualStudio.Shell                       
open Microsoft.VisualStudio.Shell.Interop                       
open FSharpVSPowerTools
open Unchecked
open Microsoft.FSharp.NativeInterop
open System.Text.RegularExpressions
open Microsoft.FSharp.Compiler.SourceCodeServices
open Microsoft.FSharp.Compiler.SimpleSourceCodeServices


[<AutoOpen>]
module Prelude =

    let guidLogicalTextView =  Guid LogicalViewID.TextView

    let inline nativeintToChar nint = Marshal.GetObjectForNativeVariant nint :?> uint16 |> char



    type ITextStructureNavigator with

        member inline self.WordBeforeCaret (textView:ITextView) =
            let point = textView.Caret.Position.BufferPosition - 1
            (self.GetExtentOfWord point).Span.GetText ()
