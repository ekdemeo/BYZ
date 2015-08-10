<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:output method="xml" indent="yes" omit-xml-declaration="yes" />

    <xsl:strip-space elements="*" />
    <xsl:template match="/">

        <xsl:apply-templates />
    </xsl:template>

    <xsl:template match="Book">
        <xsl:for-each select="Chapters/Chapter">
            \bchapter{<xsl:value-of select="@N" /><xsl:text>}</xsl:text>
            <xsl:for-each select="Verses/Verse">
                \bverse{<xsl:value-of select="@N" /><xsl:text>}</xsl:text>
                <xsl:for-each select="Words/Word">
                    <xsl:if test="@G='1'">
                        \underline{\wrd{<xsl:value-of select="@S" />}{<xsl:value-of select="@T" /><xsl:text>}}</xsl:text>
                    </xsl:if>
                    <xsl:if test="@G='2'">
                        \doubleline{\wrd{<xsl:value-of select="@S" />}{<xsl:value-of select="@T" /><xsl:text>}}</xsl:text>
                    </xsl:if>
                    <xsl:if test="@G='0'">
                        \wrd{<xsl:value-of select="@S" />}{<xsl:value-of select="@T" /><xsl:text>}</xsl:text>
                    </xsl:if>
                </xsl:for-each>
            </xsl:for-each>
        </xsl:for-each>
    </xsl:template>
</xsl:stylesheet>