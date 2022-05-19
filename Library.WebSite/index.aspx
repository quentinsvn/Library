<%@ Page Title="" Language="C#" MasterPageFile="~/library.master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Library.WebSite.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <section id="myMovies" class="padding100">
        <div class="container">
            <div class="row">
                <h2 class="background double animated wow fadeInUp" data-wow-delay="0.2s">
                    <span><strong>My</strong> movies</span>
                </h2>
            </div>
            <!-- ./ end row -->
            <div class="row">
                <div class="col-md-4">
                    <i class="fa fa-youtube-play animated wow fadeInDown"></i>
                    <div class="sc-inner">
                        <h4>
                            <asp:Literal ID="litNbMovies" runat="server" />
                        </h4>
                        <p>
                            All the movies in my library.
                        </p>
                    </div>
                </div>
                <!-- ./ end myMovies box -->
                <div class="col-md-4">
                    <i class="fa fa-list animated wow fadeInDown" data-wow-delay="0.2s"></i>
                    <div class="sc-inner">
                        <h4>
                            <asp:Literal ID="litNbGenres" runat="server" />
                        </h4>
                        <p>
                            All the genres in my library.
                        </p>
                    </div>
                </div>
                <!-- ./ end myMovies box -->
                <div class="col-md-4">
                    <i class="fa fa-gears animated wow fadeInDown" data-wow-delay="0.4s"></i>
                    <div class="sc-inner">
                        <h4>
                            Easy management !
                        </h4>
                        <p>
                            Access in one click to your movies, add new or edit existing one, manage their genres...
                        </p>
                    </div>
                </div>
                <!-- ./ end service box -->
            </div>
        </div>
    </section>
    <!-- Products Section -->
    <section id="latestMovies" class="latestMovies-list padding100">
        <div class="container">
            <div class="row">
                <div class="section-title col-sm-8 col-sm-offset-2 col-md-8 col-md-offset-2 col-lg-8 col-lg-offset-2">
                    <h2 class="animated wow fadeInLeft" data-wow-delay="0.4s">
                        My latest <span class="common">' Movies '</span>.
                        Get more...
                    </h2>                   
                </div>
            </div>
            <!-- ./end row -->
            <div class="row">
                <div class="col-sm-12 animated wow fadeInUp" data-wow-delay="0.6s">
                    <div id="screens" class="owl-carousel">
                        <asp:Repeater ID="rptLatestMovies" runat="server">
                            <ItemTemplate>                                
                                <div>
                                    <asp:Image ID="imgMovie" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ImageUrl") %>' AlternateText="screens" CssClass="img-responsive" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <!-- ./ end slider -->
                </div>
            </div>
            <!-- ./ end row -->
        </div>
    </section>
    <!-- Download Section -->
    <section id="download" class="padding100">
        <div class="container">
            <div class="row">
                <div class="section-title col-sm-8 col-sm-offset-2 col-md-8 col-md-offset-2 col-lg-8 col-lg-offset-2">
                    <h2 class="animated wow fadeInLeft" data-wow-delay="0.4s">
                        Waiting for what <span class="common">' DOWNLOAD NOW'</span>
                    </h2>                    
                </div>
            </div>
            <!-- ./end row -->
            <div class="row">
                <div class="col-sm-8 col-sm-offset-2 text-center">
                    <div class="download-wrap animated wow fadeInLeft" data-wow-delay="0.4s">
                        <a href="#" class="btn btn-download wow fadeInUp">
                            <i class="fa fa-android"></i>
                            <strong>Download App</strong>
                            <span>From Play Store</span>
                        </a>
                        <a href="#" class="btn btn-download app wow fadeInUp" data-wow-delay="0.2s">
                            <i class="fa fa-apple"></i>
                            <strong>Download App</strong>
                            <span>From App Store</span>
                        </a>
                        <a href="#" class="btn btn-download window wow fadeInUp"data-wow-delay="0.2s"><i class="fa fa-windows"></i>
                            <strong>Download App</strong>
                            <span>From windows store</span>
                        </a>
                    </div>
                </div>
            </div>
            <!-- ./end row -->
        </div>
    </section>
    <!--End Download Section end-->
</asp:Content>

