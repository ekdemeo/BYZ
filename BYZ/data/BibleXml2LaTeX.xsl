<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:template match="/">
        <xsl:text>
\documentclass[paper=a5,pagesize=pdftex]{scrbook}
\usepackage[utf8]{inputenc}
\usepackage[T1]{fontenc}
\usepackage{polski}
\usepackage[pagestyles]{titlesec}
\usepackage{lettrine}
\usepackage{setspace}
\usepackage[polish]{babel}
%\usepackage{ebgaramond}
\usepackage{lipsum}
\usepackage[usenames,dvipsnames,svgnames,table]{xcolor}
\usepackage{fancyhdr}
  \pagestyle{fancy}
  \fancyhf{}
  \fancyhead[RO,LE]{\rightmark}
  \renewcommand{\headrulewidth}{.5pt}
\selectlanguage{polish}

\newcounter{versecounter}
\renewcommand{\thesection}{\arabic{section}}
\newcommand{\theverse}{\arabic{versecounter}}

% fonts
\font\strong=phvr at 6pt

% definition of the page style with required headers
%\newpagestyle{Biblestyle}{
%  \setheadrule{.009pt}
%  \sethead[\thepage][\chaptertitle]
%    [\toptitlemarks\thesection:\toptitlemarks\theverse---%
%      \bottitlemarks\thesection:\bottitlemarks\theverse]%
%   {\toptitlemarks\thesection:\toptitlemarks\theverse---%
%     \bottitlemarks\thesection:\bottitlemarks\theverse}{\chaptertitle}{\thepage}
%}

% definition of the page style with required headers
\newpagestyle{Biblestyle}{
  \setheadrule{.009pt}
  \sethead[\thepage][\chaptertitle][]{}{\chaptertitle}{\thepage}
  %  [\toptitlemarks\thesection:\toptitlemar{ks\theverse---%
  %    \bottitlemarks\thesection:\bottitlemarks\theverse]%
  % {\toptitlemarks\thesection:\toptitlemarks\theverse---%
  %   \bottitlemarks\thesection:\bottitlemarks\theverse}{\chaptertitle}{\thepage}
}

% sets the marks to be used (section and subsection)
\setmarks{section}{subsection}

% sections and subsections formatting
\titleformat{\section}
{}{\lettrine{\thesection}}{0em}{}[\vskip-0.65\baselineskip]
\titleformat{\subsection}[runin]
{\small\bfseries}{\thesubsection}{1em}{}
\titlespacing{\section}{1em}{-1pt}{0pt}

\pagestyle{Biblestyle}

\renewcommand{\LettrineFontHook}{\bfseries}

\setlength{\parindent}{1pt}

\newlength\NumLen
\newlength\LinLen
% indents one line of text. Indentation= width of section number + 1em
\newcommand\IndOne{%
  \settowidth\NumLen{\thesection}
  \addtolength\NumLen{0.8em}
  \setlength\LinLen{\dimexpr\textwidth-\NumLen}%\the\NumLen\the\LinLen
  \parshape 2 \NumLen \LinLen 0pt \textwidth}

% indents two lines of text. Indentation= width of section number + 1em
\newcommand\IndTwo{%
  \settowidth\NumLen{\thesection}
  \addtolength\NumLen{1em}
  \setlength\LinLen{\dimexpr\textwidth-\NumLen}%\the\NumLen\the\LinLen
  \parshape 3 \NumLen \LinLen \NumLen \LinLen 0pt \textwidth}

% macros

% word
\newcommand\wrd[2]{%
  \leavevmode
  \vbox{\offinterlineskip
    \halign{%
      \hfil##\hfil\cr
      {\strong\vphantom{p}#1}\cr
      \noalign{\vskip\lineskip}%
      \vphantom{A}#2\cr
    }%
  }%
}

\newcommand*\vrs[1]{%
  \stepcounter{versecounter}%
  \textsuperscript{\bfseries #1}}

  <xsl:for-each select="catalog/cd">
      <tr>
        <td><xsl:value-of select="title" /></td>
        <td><xsl:value-of select="artist" /></td>
      </tr>
      </xsl:for-each>
</xsl:text>
    </xsl:template>
</xsl:stylesheet>