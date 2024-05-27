import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { ApiService } from './api.service';

describe('ApiService', () => {
  let service: ApiService;
  let httpMock: HttpTestingController;

  
  beforeEach(() => {
    //take the data to use
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [ApiService]
    });
    service = TestBed.inject(ApiService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
  //it fetch some data
  it('should fetch customers', () => {
    const dummyCustomers = [
      { id: 1, name: 'Jennifer Farias', email: 'jenniferFarias@example.com' },
      { id: 2, name: 'Naomy Dutra', email: 'naomyDutra@example.com' }
    ];

    //take the data and subscribe it
    service.getCustomers().subscribe(customers => {
      expect(customers.length).toBe(2);
      expect(customers).toEqual(dummyCustomers);
    });

    const req = httpMock.expectOne(`${service.baseUrl}/customers`);
    expect(req.request.method).toBe('GET');
    req.flush(dummyCustomers);
  });

  afterEach(() => {
    httpMock.verify();
  });
});

//old code
//import { TestBed } from '@angular/core/testing';

//import { ApiService } from './ApiService';

//describe('ApiService', () => {
//  let service: ApiService;

//  beforeEach(() => {
//    TestBed.configureTestingModule({});
//    service = TestBed.inject(ApiService);
//  });

//  it('should be created', () => {
//    expect(service).toBeTruthy();
//  });
//});
