# How-to-fetch-data-from-API-and-populate-in-Xamarin-Forms-ListView
Fetching data from the API is a 2 step process. You need to get the task using the API string associated with HTTPClient and process the deserialization of resultant objects using Newtonsoft.JsonConvert(You need to install the **Newtonsoft.Json** package). Check with the code usage below.

```
public ViewModel()
{
    var taskString = new HttpClient().GetStringAsync(new Uri("http://universities.hipolabs.com/search?country=United+States"));
    var modelList = JsonConvert.DeserializeObject<List<Model>>(taskString.Result);
    Items = modelList.ToList();
}
```

Here we have used an open source API from 'https://apipheny.io/free-api/' to fetch the list of universities in US. Processing the Json to C# conversion is so simple and accurate using 'https://json2csharp.com/'.

Now its time to showcase the populated 'Items' list to Xamarin.Forms ListView.

```
<ContentPage.BindingContext>
   <fetchfromapi:ViewModel/>
</ContentPage.BindingContext>

    <ListView ItemsSource="{Binding Items}">
        <ListView.ItemTemplate>
            <DataTemplate>
                <ViewCell>
                    <ViewCell.View>
                        <StackLayout Margin="5">
                            <Label Text="{Binding country, StringFormat='Country : {0}'}"/>
                            <Label Text="{Binding name, StringFormat='Name : {0}'}"/>
                            <Label>
                                <Label.FormattedText>
                                    <FormattedString>
                                        <Span Text="URL: "/>
                                        <Span Text="{Binding web_pages[0]}" TextColor="Blue" TextDecorations="Underline">
                                            <Span.GestureRecognizers>
                                                <TapGestureRecognizer Command="{Binding TapCommand}" CommandParameter="{Binding web_pages[0]}"/>
                                            </Span.GestureRecognizers>
                                        </Span>
                                    </FormattedString>
                                </Label.FormattedText>
                            </Label>
                            <BoxView HeightRequest="1" Color="#d3d3d3"/>
                        </StackLayout>
                    </ViewCell.View>
                </ViewCell>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
```
