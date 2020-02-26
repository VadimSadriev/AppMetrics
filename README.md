# AppMetrics

In order to collect metrics follow these steps:
1. Download prometheus https://prometheus.io/download/
2. Download grafana https://grafana.com/grafana/download
3. Configure prometheus to your api with something like this:
   * in prometheus.yml file in **scrape_configs** section at the very bottom add
     ```sh
     - job_name: 'customersapi'
        static_configs:
        - targets: ['localhost:5000'] // this is your appllication url
        metrics_path: /metrics-text
     ```
   * run prometheus.exe // default prometheus url: localhost:9090
4. Run grafana-server.exe // default grafana url: localhost:3000. default login: admin, default pass: admin
5. Go to localhost:3000 and choose data source as prometheus
6. This is pretty much everything you need. Once your application start receive requests prometheus will 
   scrape it every 15s (configures in prometheus.yml file) and grafana will read that data.
