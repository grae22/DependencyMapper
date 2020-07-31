using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Linq;

namespace DependencyMapper.GraphViz
{
  class GraphVizDiagram
  {
    //-------------------------------------------------------------------------

    public class Node
    {
      //-----------------------------------------------------------------------

      public enum NodeShape
      {
        BOX,
        CIRCLE,
        ELLIPSE,
        PENTAGON,
        HEXAGON,
        OCTAGON,
        HOUSE,
        INV_HOUSE,
        TRAPEZIUM,
        INV_TRAPEZIUM
      }

      public int Id { get; private set; }
      public string Text { get; private set; }
      public Color Colour { get; private set; }
      public NodeShape Shape { get; private set; }
      public List<int> Links { get; private set; }

      //-----------------------------------------------------------------------

      public Node( int id,
                   string text,
                   Color colour,
                   NodeShape shape )
      {
        Id = id;
        Text = text;
        Colour = colour;
        Shape = shape;

        Links = new List<int>();
      }

      //-----------------------------------------------------------------------

      public void AddLink( int id )
      {
        if( Links.Contains( id ) == false )
        {
          Links.Add( id );
        }
      }

      //-----------------------------------------------------------------------

      public string ShapeAsString()
      {
        switch( Shape )
        {
          case NodeShape.BOX:
            return "box";

          case NodeShape.CIRCLE:
            return "circle";

          case NodeShape.ELLIPSE:
            return "ellipse";

          case NodeShape.PENTAGON:
            return "polygon sides=5";

          case NodeShape.HEXAGON:
            return "polygon sides=6";

          case NodeShape.OCTAGON:
            return "polygon sides=8";

          case NodeShape.HOUSE:
            return "house";

          case NodeShape.INV_HOUSE:
            return "invhouse";

          case NodeShape.TRAPEZIUM:
            return "trapezium";

          case NodeShape.INV_TRAPEZIUM:
            return "invtrapezium";

          default:
            return "box";
        }
      }
    }

    //=========================================================================

    private const string c_tmpFolder = "GraphVisTmp";
    private const string c_newLine = @"\n";

    public Dictionary<int, Node> Nodes { get; private set; }

    private string _absGraphVizBinPath;
    private string _absTemplateFilename;

    //-------------------------------------------------------------------------

    public GraphVizDiagram( string absGraphVizBinPath,
                            string relTemplateFilename )
    {
      Nodes = new Dictionary<int,Node>();

      // GraphViz path.
      _absGraphVizBinPath = absGraphVizBinPath;

      if( _absGraphVizBinPath != null )
      {
        if( _absGraphVizBinPath[ _absGraphVizBinPath.Length - 1 ] !=  '\\' && 
            _absGraphVizBinPath[ _absGraphVizBinPath.Length - 1 ] !=  '/' )
        {
          _absGraphVizBinPath += '\\';
        }
      }

      if( _absGraphVizBinPath == null ||
          Directory.Exists( _absGraphVizBinPath ) == false )
      {
        throw new ArgumentNullException(
          "GraphViz bin path is null or was not found (" + _absGraphVizBinPath + ")." );
      }

      // Template file.
      if( relTemplateFilename == null )
      {
        throw new ArgumentNullException( "Template filename is null." );
      }

      _absTemplateFilename =
        Path.GetDirectoryName(
          System.Reflection.Assembly.GetExecutingAssembly().Location ) + '\\' + relTemplateFilename;

      if( File.Exists( _absTemplateFilename ) == false )
      {
        throw new ArgumentNullException(
          "Template file was not found (" + _absTemplateFilename + ")." );
      }
    }

    //-------------------------------------------------------------------------

    // maxCharsBeforeWrappingText: Set to 0 for no wrapping.

    public Node AddNode( int id,
                         string header,
                         string title,
                         string text,
                         int maxCharsBeforeWrappingText,
                         Color colour,
                         Node.NodeShape shape )
    {
      if( Nodes.ContainsKey( id ) == false )
      {
        title = WrapText( title, maxCharsBeforeWrappingText, "CENTER" );
        text = WrapText( text, maxCharsBeforeWrappingText, "LEFT" );

        string nodeText = $"<SUP>{header}</SUP><BR ALIGN='CENTER' /><B>{title}</B>";

        if (text.Any())
        {
          nodeText = $"{nodeText}<BR ALIGN='CENTER' />{text}";
        }

        Node newNode =
          new Node(
            id,
            $"{nodeText}<br/>&nbsp;",
            colour,
            shape );

        Nodes.Add( id, newNode );

        return newNode;
      }

      return Nodes[ id ];
    }

    //-------------------------------------------------------------------------

    public void AddLinkToNode( int nodeId, int linkId )
    {
      if( Nodes.ContainsKey( nodeId ) )
      {
        Nodes[ nodeId ].AddLink( linkId );
      }
    }

    //-------------------------------------------------------------------------

    public string CreateDiagram(in string filename = null)
    {
      try
      {
        // Read the template.
        string buffer = File.ReadAllText( _absTemplateFilename );

        // Compile the nodes & links text;
        var nodesText = new StringBuilder();
        var linksText = new StringBuilder();

        foreach( Node n in Nodes.Values )
        {
          string thisNodeIdAsString = n.Id.ToString();

          nodesText.Append("  ");
          nodesText.Append(thisNodeIdAsString);
          nodesText.Append(" [");
          nodesText.Append("label=<");
          nodesText.Append(n.Text.Replace('"', '\''));
          nodesText.Append("> ");
          nodesText.Append("shape=");
          nodesText.Append(n.ShapeAsString());
          nodesText.Append(" ");
          nodesText.Append("fillcolor=\"#");
          nodesText.Append(n.Colour.R.ToString("X2"));
          nodesText.Append(n.Colour.G.ToString( "X2" ));
          nodesText.Append(n.Colour.B.ToString( "X2" ));
          nodesText.Append("\"");
          nodesText.Append("];");
          nodesText.Append(Environment.NewLine);

          foreach( int id in n.Links )
          {
            if( Nodes.ContainsKey( id ) )
            {
              linksText.Append("  ");
              linksText.Append(thisNodeIdAsString);
              linksText.Append(" -> ");
              linksText.Append(id.ToString());
              linksText.Append(Environment.NewLine);
            }
          }
        }

        buffer = buffer.Replace( "<INSERT_NODES_HERE>", nodesText.ToString() );
        buffer = buffer.Replace( "<INSERT_LINKS_HERE>", linksText.ToString() );

        // Write the gv file
        string gvFilename = filename + ".gv";
        File.WriteAllText( gvFilename, buffer );

        // Get graphvis to generate the diagram.
        string diagramFilename = filename + ".png";

        ProcessStartInfo info =
          new ProcessStartInfo(
            _absGraphVizBinPath + "dot.exe",
            "\"" + gvFilename + "\" -o \"" + diagramFilename + "\" -T png" );

        info.CreateNoWindow = true;
        info.UseShellExecute = false;

        Process proc = Process.Start( info );

        proc.WaitForExit( 10000 );

        // Clean up.
        File.Delete( gvFilename );

        return diagramFilename;
      }
      catch( Exception ex )
      {
        throw ex;
      }
    }

    //-------------------------------------------------------------------------

    // Deletes contents for the GraphVisTmp

    public static void CleanupTmpFolder()
    {
      try
      {
        string absPath =
          Path.GetDirectoryName(
            System.Reflection.Assembly.GetExecutingAssembly().Location ) + '\\' + c_tmpFolder;

        if( Directory.Exists( absPath ) )
        {
          string[] files = Directory.GetFiles( absPath );

          foreach( string filename in files )
          {
            File.Delete( filename );
          }
        }
      }
      catch( Exception )
      {
        // Ignore.
      }
    }

    //-------------------------------------------------------------------------

    private string WrapText( string text,
                             int wrapThreshold,
                             string alignment )
    {
      if( text == null || wrapThreshold < 1 )
      {
        return text;
      }

      // Wrap the text?
      if( wrapThreshold > 0 &&
          text.Length > wrapThreshold )
      {
        // Iterate through all chars in text.
        bool isHtmlTagOpen = false;

        for( int i = 0; i + wrapThreshold < text.Length; )
        {
          // Find the end of the last word that can be on the current line.
          int endOfLastWordIndex = 0;
          bool foundBreak = false;

          for( int c = i; c < i + wrapThreshold; c++ )
          {
            if( text[ c ] == '<' )
            {
              isHtmlTagOpen = true;

              if( text.IndexOf( "<BR", c ) == c )
              {
                foundBreak = true;
                break;
              }
            }
            else if( text[ c ] == '>' )
            {
              isHtmlTagOpen = false;
            }

            if( isHtmlTagOpen == false &&
                text[ c ] == ' ' )
            {
              endOfLastWordIndex = c;
            }
          }

          if( foundBreak )
          {
            //i += wrapThreshold;
            i++;
            continue;
          }

          if( endOfLastWordIndex == 0 )
          {
            endOfLastWordIndex = i + wrapThreshold;
          }

          // Add new-line to end the current line.
          text = text.Insert( endOfLastWordIndex, "<BR ALIGN='" + alignment + "' />" );

          // Next line.
          i = endOfLastWordIndex + ( "<BR ALIGN='" + alignment + "' />" ).Length + 1;
        }
      }

      return text;
    }

    //-------------------------------------------------------------------------
  }
}
