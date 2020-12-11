<template>
  <div id="app" :class="typeof weather.main != 'undefined' && weather.main.temp < 0 ? 'warm' : ''">
    <main>
      <div class="search-box">
        <input
            type="text"
            class="search-bar"
            placeholder="Поиск..."
            v-model="query"
            @keypress="fetchWeather"
        />

      </div>
      <div class="weather-wrap" v-if="typeof weather.main != 'undefined'">
        <div class="location-box">
          <div class="location">
            {{ weather.name }}, {{weather.sys.country }}
          </div>
          <div class="date">
            {{ dateBuilder() }}
          </div>
          <div class="weather-box">
            <div class="temp">
              {{ Math.round(weather.main.temp) +" "}}°C или {{Math.round(weather.main.temp) +273}}K
            </div>
            <div class="weather" v-if="weather.weather[0].main=='Clouds'">облачно</div>
            <div class="weather" v-else-if="weather.weather[0].main=='Rain'">дождливо</div>
            <div class="weather" v-else-if="weather.weather[0].main=='Clear'">ясно.</div>
            <div class="weather" v-else-if="weather.weather[0].main=='Snow'">снежно</div>
            <div class="weather" v-else-if="weather.weather[0].main=='Haze'">пассмурно</div>
          </div>
        </div>
      </div>
    </main>
  </div>
</template>

<script>


export default {
  name: 'app',
  data() {
    return {
      api_key: 'fbfcb16a4427df6a4e6b83ba3e593d79',
      url_base: 'https://api.openweathermap.org/data/2.5/',
      query: '',
      weather: {}
    }
  },
  methods:{
    fetchWeather (e) {
      if (e.key == "Enter") {
        fetch(`${this.url_base}weather?q=${this.query}&units=metric&APPID=${this.api_key}`)
            .then(res =>{
              return res.json();
            }).then(this.setResults);
      }
    },
    setResults (results) {
      this.weather = results;
    },
    dateBuilder () {
      let d = new Date();
      let months = ["Января", "Февраля", "Мара", "Апреля", "Мая", "Июня", "Июля", "Августа", "Сентября", "Октября", "Ноября", "Декабря"];
      let days = ["воскресенье", "понедельник", "вторник", "среда", "четверг", "пятница", "суббота", ]
      let day = days[d.getDay()];
      let date = d.getDate();
      let month = months[d.getMonth()];
      let year = d.getFullYear();
      return `${day} ${date} ${month} ${year}`;
    }
  }
}
</script>

<style>
*{
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}
body{
  font-family: cursive;
}
#app{
  background-image: url('https://mirpozitiva.ru/wp-content/uploads/2019/11/1477469619_zakat-1024x640.jpg');
  background-size: cover;
  background-position: bottom;
  transition: 0.4s;
}
#app.warm{
  background-image: url("https://storge.pic2.me/c/1360x800/574/km8x8gbirnl5.jpg");
}

main{
  min-height: 100vh;
  padding: 25px;
  background-image: linear-gradient(to bottom, rgba(0, 0, 0, 0.15), rgba(0, 0, 0, 100));
}
.search-box .search-bar{
  font-family: cursive;
  display: block;
  width:100%;
  margin-bottom: 30px;
  padding: 15px;
  color: #313131;
  font-size: 20px;
  appearance: none;
  border: none;
  outline: none;
  background-color: rgba(255, 255, 255, 0.5) ;
  border-top-left-radius: 40px 50px;
  border-bottom-left-radius: 40px 50px;
  border-top-right-radius: 40px 50px;
  border-bottom-right-radius: 40px 50px;
  transition: 0.4s;
  box-shadow: 0px 20px 10px black;
}

.location-box .location{
  color: white;
  font-size: 50px;
  font-weight: 500;
  text-align: center;
  text-shadow: 5px 5px black;
}
.location-box .date{
  color: white;
  font-size: 30px;
  font-weight: 500;
  text-align: center;
  font-style: oblique;
}
.weather-box{
  text-align: center;
}
.weather-box .temp{
  display: inline-block;
  padding: 10px 40px 40px;
  color: white;
  font-size: 100px;
  font-weight: 500;
  text-shadow: 7px 5px black;
  background-color: rgba(255, 255, 255, 0.5);
  border-radius: 15px;
  margin: 20px 0px;
  box-shadow: 10px 10px black;
}

.weather-box .weather{
  color: white;
  font-size: 50px;
  font-weight: 700;
  font-style:oblique;
  text-shadow: 5px 5px black;

}
</style>




