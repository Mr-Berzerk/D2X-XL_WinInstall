Imports System.IO
Public Class WildCard
    'this procedure takes a source, destination and file extension, which search for that extension, and then copies
    'all files with with that extension from the source to the destination, it can also take extensions that are .xx? 
    'where ? is the only changing character in the extension.
    Public Sub EXTSearchAndCopy(ByVal source As String, ByVal SearchEXT As String, ByVal destination As String)
        Dim currentDir As New DirectoryInfo(source)
        Dim xfile As String = ""
        Dim FilenameAndPath As String = ""
        Dim ext As String = ""
        If SearchEXT.Length = 3 Then
            Dim DecreasedEXT As String
            For Each File As FileInfo In currentDir.GetFiles
                FilenameAndPath = File.FullName
                xfile = System.IO.Path.GetFileName(FilenameAndPath)
                If Not File Is Nothing Then
                    If File.Length > 0 Then
                        ext = System.IO.Path.GetExtension(xfile).ToLower
                        If ext.Length > 0 Then
                            DecreasedEXT = ext.Remove(ext.Length - 1, 1)
                            If DecreasedEXT = SearchEXT Then
                                My.Computer.FileSystem.CopyFile(FilenameAndPath, destination & xfile, True)
                                SetAttr(destination & xfile, FileAttribute.Normal)
                            End If
                        End If
                    End If
                End If
            Next
        Else
            For Each File As FileInfo In currentDir.GetFiles
                FilenameAndPath = File.FullName
                xfile = System.IO.Path.GetFileName(FilenameAndPath)
                If Not File Is Nothing Then
                    If File.Length > 0 Then
                        ext = System.IO.Path.GetExtension(xfile).ToLower
                        If ext.Length > 0 Then
                            If ext = SearchEXT Then
                                My.Computer.FileSystem.CopyFile(FilenameAndPath, destination & xfile, True)
                                SetAttr(destination & xfile, FileAttribute.Normal)
                            End If
                        End If
                    End If
                End If
            Next
            'For Each dir As DirectoryInfo In currentDir.GetDirectories()
            'WildCardCopy(Dir.FullName, SearchEXT, destination)
            'Next
        End If
    End Sub
End Class
