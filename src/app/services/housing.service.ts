import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { connectableObservableDescriptor } from 'rxjs/internal/observable/ConnectableObservable';
import { Observable } from 'rxjs';
import { IProperty } from '../model/iproperty';
import { IPropertyBase } from '../model/ipropertybase';
import { Property } from '../model/property';
import { environment } from 'src/environments/environment';
import { getDate } from 'ngx-bootstrap/chronos/utils/date-getters';

@Injectable({
  providedIn: 'root'
})
export class HousingService {
  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }

   getAllCities(): Observable<string[]> {
     return this.http.get<string[]>('http://localhost:5000/api/city');
   }

  getProperty(id:number){
    return this.http.get<Property>(this.baseUrl + '/property/detail/'+id.toString());
  }

  getAllProperties(SellRent?: number): Observable<Property[]> {
    return this.http.get<Property[]>(this.baseUrl + '/property/list/'+SellRent.toString());
  }

  addProperty(property: Property) {
    let newProp = [property];

    // Add new property in array if newProp alreay exists in local storage
    if (localStorage.getItem('newProp')) {
      newProp = [property,
                  ...JSON.parse(localStorage.getItem('newProp'))];
    }

    localStorage.setItem('newProp', JSON.stringify(newProp));
  }


  newPropID() {
    if (localStorage.getItem('PID')) {
      localStorage.setItem('PID', String(+localStorage.getItem('PID') + 1));
      return +localStorage.getItem('PID');
    } else {
      localStorage.setItem('PID', '101');
      return 101;
    }
  }

  getPropertyAge(dateofEstablishment: Date): string{
    const today = new Date();
    const estDate = new Date(dateofEstablishment);
    let age = today.getFullYear() - estDate.getFullYear();
    const m = today.getMonth() - estDate.getMonth();

    //Current month smaller than establishment month or same month but current date smaller than establishment date


    if(m<0 || (m===0 && today.getDate() < estDate.getDate())){
      age --;
    }

    if(age ===0){
      return 'Less than a year';
    }

    return age.toString();
  }

}
