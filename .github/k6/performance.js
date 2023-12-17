import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
    duration: '1m',
    vus: 25,
    thresholds: {
        http_req_failed: ['rate<0.01'], // http errors should be less than 1%
        http_req_duration: ['p(95)<1000'], // 95 percent of response times must be below 2000ms
    },
};

export default function () {
    const res = http.get('https://inte-bloodpressurecalculator-staging.azurewebsites.net');
    sleep(1);
}